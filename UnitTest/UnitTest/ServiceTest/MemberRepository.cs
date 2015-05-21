using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ServiceTest
{
    public interface IMemberRepository<out T>
    {
        List<Member> GetAll();
    }
}
