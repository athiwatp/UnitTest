using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTest
{
    [TestFixture]
    public class MyFirstTest
    {
        [Test]
        public void PositiveTest()
        {
            int a = 5;
            int b = 5;
            Assert.AreEqual(a, b);
        }

        [Test]
        public void NegativeTest()
        {
            Assert.Fail("Test failed case");
        }

        [Test,ExpectedException(typeof(NotSupportedException))]
        public void ExceptionTest()
        {
            throw new NotSupportedException();
        }

        [Test, Ignore]
        public void NotImplementTest()
        {
            throw new NotImplementedException();
        }
    }
}
