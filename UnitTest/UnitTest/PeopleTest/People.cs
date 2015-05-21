using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.PeopleTest
{
    public class People
    {
        private readonly IRepository<Person> _repository;

        public People(IRepository<Person> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Person> Query(Func<Person, bool> predicate)
        {
            return this._repository.GetAll().Where(predicate).ToList();
        }
    }
}
