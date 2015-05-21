describe("Angular Controller",function(){
	var controller;
	
	beforeEach(function() {
		controller = new Controller();
	});
	
	it("is 1 is first page", function(){
		var page = 1;
		expect(controller.isFirstPage(page)).toBe(true);
	});
	
	it("is 3 is not first page", function(){
		var page = 3;
		expect(controller.isFirstPage(page)).toBe(false);
	});
	
	it("is 4 is not last page of 10 item array", function(){
		var page = 4;
		var length = 10;
		expect(controller.isLastPage(page,length)).toBe(false);
	});
	
	it("is 10 is last page of 10 item array", function(){
		var page = 10;
		var length = 10;
		expect(controller.isLastPage(page,length)).toBe(true);
	});
	
	it("change page from page 2 to page 4", function(){
		var page = 4;
		controller.currentPage = 2;
		controller.changePage(page);
		expect(controller.currentPage).toBe(page);
	});
	
	it("is 14 items is 3 page count of 5 item per page condition", function(){
		var itemCount = 14;
		var perpage = 5;
		expect(controller.countPage(itemCount,perpage)).toBe(3);
	});
	
	it("is 17 items is not 4 page for 6 item per page condition", function(){
		var itemCount = 14;
		var perpage = 6;
		expect(controller.countPage(itemCount,perpage)).not.toBe(4);
	});
	
	it("is empty when remove all data", function(){
		controller.dataList = [1,2,3];
		controller.removeAllData();
		expect(controller.dataList.length).toBe(0);
	});
	
	it("get right index of item", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
		];
		var item = {name:'item2'}
		expect(controller.getIndexOfItem(item,list)).toBe(1);
	});
	
	it("getindex return -1 when obj is not in list", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
		];
		var item = {name:'item4'}
		expect(controller.getIndexOfItem(item,list)).toBe(-1);
	});
	
	it("is this exist item already exist", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
		];
		var item = {name:'item3'}
		expect(controller.isAlreadyExist(item,list)).toBe(true);
	});
	
	it("is this not exist item not already exist", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
		];
		var item = {name:'item'}
		expect(controller.isAlreadyExist(item,list)).toBe(false);
	});
	
	it("check show list is right list with 10 item in list with 5 perpage and current page is 2", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
			{name:'item4'},
			{name:'item5'},
			{name:'item6'},
			{name:'item7'},
			{name:'item8'},
			{name:'item9'},
			{name:'item10'}
		];
		var showList = [
			{name:'item6'},
			{name:'item7'},
			{name:'item8'},
			{name:'item9'},
			{name:'item10'}
		];
		var page = 2;
		var perpage = 5;
		expect(controller.getShowList(page,perpage,list)).toEqual(showList);
	});
	
	it("check show list is right list with 12 item in list and 5 perpage on page 3", function(){
		var list = [
			{name:'item1'},
			{name:'item2'},
			{name:'item3'},
			{name:'item4'},
			{name:'item5'},
			{name:'item6'},
			{name:'item7'},
			{name:'item8'},
			{name:'item9'},
			{name:'item10'},
			{name:'item11'},
			{name:'item12'}
		];
		var showList = [
			{name:'item11'},
			{name:'item12'}
		];
		var page = 3;
		var perpage = 5;
		expect(controller.getShowList(page,perpage,list)).toEqual(showList);
	});
	
});
























