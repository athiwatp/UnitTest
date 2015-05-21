using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace UnitTest.PeopleTest
{
    [TestFixture]
    public class PeopleTestWithMoq
    {
        Mock<IRepository<Person>> mockRepo;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Person>>();
        }

        [Test]
        public void ShouldReturnTwoPersonWithFirstNamePeter()
        {
            var data = new List<Person>
            {
                new Person {FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Person {FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Person {FirstName = "John", LastName = "Smith" , Age = 25},
                new Person {FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Person {FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            mockRepo.Setup(f => f.GetAll()).Returns(data);

            var people = new People(mockRepo.Object);
            var person = people.Query(p => p.FirstName.Equals("Peter"));

            Assert.AreEqual(person.Count(), 2);
        }

        [Test]
        public void ShouldReturnTwoPersonWithLastNameSmith()
        {
            var data = new List<Person>
            {
                new Person {FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Person {FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Person {FirstName = "John", LastName = "Smith" , Age = 25},
                new Person {FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Person {FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            mockRepo.Setup(f => f.GetAll()).Returns(data);

            var people = new People(mockRepo.Object);
            var person = people.Query(p => p.LastName.Equals("Smith"));

            Assert.AreEqual(person.Count(), 2);
        }

        [Test]
        public void ShouldReturnOnePersonUnder20YeasOld()
        {
            var data = new List<Person>
            {
                new Person {FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Person {FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Person {FirstName = "John", LastName = "Smith" , Age = 25},
                new Person {FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Person {FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            mockRepo.Setup(f => f.GetAll()).Returns(data);

            var people = new People(mockRepo.Object);
            var person = people.Query(p => p.Age < 20);

            Assert.AreEqual(person.Count(), 1);
            Assert.AreEqual(person.FirstOrDefault().FirstName,"Peter");
        }

        [Test]
        public void ShouldReturnOnePersonMore30YeasOld()
        {
            var data = new List<Person>
            {
                new Person {FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Person {FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Person {FirstName = "John", LastName = "Smith" , Age = 25},
                new Person {FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Person {FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            mockRepo.Setup(f => f.GetAll()).Returns(data);

            var people = new People(mockRepo.Object);
            var person = people.Query(p => p.Age > 30);

            Assert.AreEqual(person.Count(), 1);
            Assert.AreEqual(person.FirstOrDefault().FirstName, "Peter");
        }
    }
}
