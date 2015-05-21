function Controller() {
}

Controller.prototype.plus = function(num1,num2){
	return num1+num2;
};

Controller.prototype.isFirstPage = function(currentPage){
	return (currentPage == 1);
};

Controller.prototype.isLastPage = function(currentPage,pageLength){
	return (currentPage == pageLength)
};

Controller.prototype.changePage = function(page){
	this.currentPage = page;
};

Controller.prototype.countPage = function(dataCount,perPage){
	return Math.ceil(dataCount/perPage);
};

Controller.prototype.removeAllData = function(){
	this.dataList = [];
};

Controller.prototype.getIndexOfItem = function(item,list){
	for (var i = 0; i < list.length; i++) {
		if (list[i].name == item.name) {
			return i;
		}
	}
	return -1;
};

Controller.prototype.isAlreadyExist = function(item,list){
	for (var i = 0; i < list.length; i++) {
		if (list[i].name == item.name) {
			return true;
		}
	}
	return false;
};

Controller.prototype.getShowList = function(page,perpage,list){
	var showList = [];
	var start = (perpage*page)-perpage;
	var limit = perpage*page;
	for(var i= start;i < limit;i++){
		if(list.length > i)
			showList.push(list[i]);
	}
	return showList;
};