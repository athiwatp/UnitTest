function MemberService(memberList) {
    if(memberList === undefined){
        this.memberList = [];
    } else {
        this.memberList = memberList;
    }
}

MemberService.prototype.getMemberById = function (id) {
    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Id == id)
            return this.memberList[i];
    }
};

MemberService.prototype.getAllMember = function () {
    return this.memberList;
};

MemberService.prototype.getAllMemberWithSameName = function (name) {
    var member = [];

    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Name == name)
            member.push(this.memberList[i]);
    }

    return member;
};

MemberService.prototype.getAllMemberWithSameAge = function (age) {
    var member = [];

    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Age == age)
            member.push(this.memberList[i]);
    }

    return member;
};

MemberService.prototype.getMemberCount = function () {
    return this.memberList.length;
};

MemberService.prototype.getMemberCountByName = function (name) {
    var count = 0;

    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Name == name)
            count++;
    }

    return count;
};

MemberService.prototype.getMemberCountByAge = function (age) {
    var count = 0;

    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Age == age)
            count++;
    }

    return count;
};

MemberService.prototype.isAlreadyExist = function (id) {
    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Id == id)
            return true;
    }

    return false;
};

MemberService.prototype.addNewMember = function (member) {
    this.memberList.push(member);
};

MemberService.prototype.deleteMember = function (id) {
    for (var i = 0; i < this.memberList.length ; i++) {
        if (this.memberList[i].Id == id) {
            this.memberList.splice(i, 1);
            break;
        }
    }
};

MemberService.prototype.getMemberAverageAge = function () {
    var sum = 0;
    for (var i = 0; i < this.memberList.length ; i++) {
        sum = sum + this.memberList[i].Age;
    }

    return parseFloat(sum / this.memberList.length).toFixed(2);
};

MemberService.prototype.removeAllMember = function () {
    this.memberList = [];
};