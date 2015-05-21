using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace UnitTest.ServiceTest
{
    [TestFixture]
    public class MemberServiceTest
    {
        Mock<IMemberRepository<Member>> mockRepo;
        MemberService MemberService;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IMemberRepository<Member>>();

            var data = new List<Member>
            {
                new Member {MemberID = 1, FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Member {MemberID = 2, FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Member {MemberID = 3, FirstName = "John", LastName = "Smith" , Age = 25},
                new Member {MemberID = 4, FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Member {MemberID = 5, FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            mockRepo.Setup(f => f.GetAll()).Returns(data);

            MemberService = new MemberService(mockRepo.Object);
        }

        [Test]
        public void GetAllMemberTest()
        {
            var data = new List<Member>
            {
                new Member {MemberID = 1, FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Member {MemberID = 2, FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Member {MemberID = 3, FirstName = "John", LastName = "Smith" , Age = 25}
            };

            var mock = new Mock<IMemberRepository<Member>>();
            mock.Setup(f => f.GetAll()).Returns(data);
            MemberService Service = new MemberService(mock.Object);

            CollectionAssert.AreEquivalent(Service.GetAllMember(),data);
        }

        [Test]
        public void GetMemberByIdTest()
        {
            Assert.AreEqual(MemberService.GetMemberById(1).FirstName, "Peter");
            Assert.AreEqual(MemberService.GetMemberById(2).FirstName, "Peter");
            Assert.AreEqual(MemberService.GetMemberById(3).FirstName, "John");
            Assert.AreEqual(MemberService.GetMemberById(4).FirstName, "Laura");
            Assert.AreEqual(MemberService.GetMemberById(5).FirstName, "Donald");
        }

        [Test]
        public void GetMemberCountTest()
        {
            Assert.AreEqual(MemberService.GetMemberCount(), 5);
        }

        [Test]
        public void GetMemberAverageAgeTest()
        {
            Assert.AreEqual(MemberService.GetMemberAverageAge(), 24.2);
        }
    }
}
