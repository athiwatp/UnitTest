using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.PeopleTest
{
    public interface IRepository<out T> where T : DomainObject
    {
        IEnumerable<T> GetAll();
    }

    public class PersonRepository : IRepository<Person>
    {
        private static IEnumerable<Person> _people;

        private static IEnumerable<Person> GetPeople()
        {
            if (_people != null) return _people;

            _people = new List<Person>
            {
                new Person {FirstName = "Peter", LastName = "Jackson" , Age = 31},
                new Person {FirstName = "Peter", LastName = "Copterman", Age = 19},
                new Person {FirstName = "John", LastName = "Smith" , Age = 25},
                new Person {FirstName = "Laura", LastName = "Smith" , Age = 23},
                new Person {FirstName = "Donald", LastName = "Orgardo", Age = 23}
            };

            return _people;
        }

        public IEnumerable<Person> GetAll()
        {
            return GetPeople();
        }
    }
}
