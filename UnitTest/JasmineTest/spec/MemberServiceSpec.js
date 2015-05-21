describe("Test MemberService",function(){
	var memberService = new MemberService([
            {
                "Id": "001",
                "Name": "Jack",
                "Age": 29
            },
            {
                "Id": "002",
                "Name": "Romanov",
                "Age": 24
            },
            {
                "Id": "003",
                "Name": "Rosan",
                "Age": 22
            },
            {
                "Id": "004",
                "Name": "Bettie",
                "Age": 19
            },
            {
                "Id": "005",
                "Name": "Peter",
                "Age": 24
            },
            {
                "Id": "006",
                "Name": "Jack",
                "Age": 19
            },
            {
                "Id": "007",
                "Name": "Sophie",
                "Age": 24
            }
	]);

	//beforeEach(function () {
	//    var memberList = [
    //        {
    //            "Id": "001",
    //            "Name": "Jack",
    //            "Age": 29
    //        },
    //        {
    //            "Id": "002",
    //            "Name": "Romanov",
    //            "Age": 24
    //        },
    //        {
    //            "Id": "003",
    //            "Name": "Rosan",
    //            "Age": 22
    //        },
    //        {
    //            "Id": "004",
    //            "Name": "Bettie",
    //            "Age": 19
    //        },
    //        {
    //            "Id": "005",
    //            "Name": "Peter",
    //            "Age": 24
	//        },
    //        {
    //            "Id": "006",
    //            "Name": "Jack",
    //            "Age": 19
    //        },
    //        {
    //            "Id": "007",
    //            "Name": "Sophie",
    //            "Age": 24
    //        }
	//    ];

	//    memberService = new MemberService(memberList);
	//});
	
	it("Count all member should be 7", function () {
	    expect(memberService.getMemberCount()).toBe(7);
	});

	it("Get member with id 1 should be jack object", function () {
	    var actual = {
	        "Id": "001",
	        "Name": "Jack",
	        "Age": 29
	    };

	    expect(memberService.getMemberById("001")).toEqual(actual);
	});
	
	it("Get member count by mame \"Jack\" should be 2", function () {
	    expect(memberService.getMemberCountByName("Jack")).toBe(2);
	});
	
	it("Remove Rosan from member list so membercount should be 6", function () {
	    memberService.deleteMember("003");
	    console.log(memberService.getAllMember());
	    expect(memberService.getMemberCount()).toBe(6);
	});
	
	it("Check Rosan doesn't exist anymore", function () {
	    console.log(memberService.getAllMember());
	    expect(memberService.isAlreadyExist("003")).toBe(false);
	});
	
	it("Get all member average age should be 23.17", function(){
	    expect(parseFloat(memberService.getMemberAverageAge())).toBe(23.17);
	});
	
	it("Get member count by age 19 should be 2", function(){
	    expect(memberService.getMemberCountByAge(19)).toBe(2);
	});
	
	it("Remove Peter from memberlist so member count should be 5", function(){
	    memberService.deleteMember("005");

	    expect(memberService.getMemberCount()).toBe(5);
	});
	
	it("Add Phillipe to memberlist and check he is exist in the list", function(){
	    var phillipe = {
	        "Id": "008",
            "Name": "Phillipe",
            "Age": 22
	    };
	    memberService.addNewMember(phillipe)
	    expect(memberService.isAlreadyExist("008")).toBe(true);
	});
	
	it("Check member list count after add Phillipe should be 6", function(){
	    expect(memberService.getMemberCount()).toBe(6);
	});
	
	it("get all member with age 19 should be the same list as actual", function(){
		var actual = [
			{
			    "Id": "004",
			    "Name": "Bettie",
			    "Age": 19
			},
			{
			    "Id": "006",
			    "Name": "Jack",
			    "Age": 19
			}
		];
		expect(memberService.getAllMemberWithSameAge(19)).toEqual(actual);
	});
	
	it("Get all member with name jack", function(){
	    var actual = [
			{
			    "Id": "001",
			    "Name": "Jack",
			    "Age": 29
			},
			{
			    "Id": "006",
			    "Name": "Jack",
			    "Age": 19
			}
	    ];
	    expect(memberService.getAllMemberWithSameName("Jack")).toEqual(actual);
	});
	
	it("Remove all member and check member list count is 0", function () {
	    memberService.removeAllMember();
	    expect(memberService.getMemberCount()).toBe(0);
	});
	
});
























