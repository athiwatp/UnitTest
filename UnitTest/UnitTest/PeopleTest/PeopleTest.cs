using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTest.PeopleTest;

namespace UnitTest.PeopleTest
{
    [TestFixture]
    public class PeopleTest
    {
        [Test]
        public void ShouldReturnTwoPersonWithFirstNamePeter()
        {
            // Setup
            var repository = new PersonRepository();
            var people = new People(repository);

            // Action
            var persons = people.Query(p => p.FirstName == "Peter");

            // Verify the result
            Assert.AreEqual(persons.Count(), 2, "Should return 2 persons with first name Peter.");
        }

        [Test]
        public void ShouldReturnTwoPersonWithLastNameSmith()
        {
            // Setup
            var repository = new PersonRepository();
            var people = new People(repository);

            // Action
            var persons = people.Query(p => p.LastName == "Smith");

            // Verify the result
            Assert.AreEqual(persons.Count(), 2, "Should return 2 persons with last name Smith.");
        }

        [Test]
        public void ShouldReturnOnePersonUnder20YeasOld()
        {
            // Setup
            var repository = new PersonRepository();
            var people = new People(repository);

            // Action
            var persons = people.Query(p => p.Age < 20);

            // Verify the result
            Assert.AreEqual(persons.Count(), 1);
            Assert.AreEqual(persons.FirstOrDefault().FirstName, "Peter");
        }

        [Test]
        public void ShouldReturnOnePersonMore30YeasOld()
        {
            // Setup
            var repository = new PersonRepository();
            var people = new People(repository);

            // Action
            var persons = people.Query(p => p.Age > 30);

            // Verify the result
            Assert.AreEqual(persons.Count(), 1);
            Assert.AreEqual(persons.FirstOrDefault().FirstName, "Peter");
        }
    }
}
