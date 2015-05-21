using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ServiceTest
{
    public class MemberService
    {
        private readonly IMemberRepository<Member> _repository;

        public MemberService(IMemberRepository<Member> repository)
        {
            this._repository = repository;
        }

        public List<Member> GetAllMember()
        {
            return this._repository.GetAll().OrderBy(m=>m.MemberID).ToList();
        }

        public Member GetMemberById(int Id)
        {
            return this._repository.GetAll().SingleOrDefault(m => m.MemberID.Equals(Id));
        }

        public int GetMemberCount()
        {
            return this._repository.GetAll().Count;
        }

        public double GetMemberAverageAge()
        {
            return this._repository.GetAll().Average(m => m.Age);
        }
    }
}
