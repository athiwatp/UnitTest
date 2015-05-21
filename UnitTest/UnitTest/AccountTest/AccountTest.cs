using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void Init()
        {
          source = new Account();
          source.Deposit(350m);

          destination = new Account();
          destination.Deposit(200m);
        }

        [Test]
        public void TransferFunds()
        {
          source.TransferFunds(destination, 100m);

          Assert.AreEqual(300m, destination.Balance);
          Assert.AreEqual(250m, source.Balance);
        }

        [Test]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferWithInsufficientFunds()
        {
          source.TransferFunds(destination, 400m);
        }

        [Test]
        [Ignore("Decide how to implement transaction management")]
        public void TransferWithInsufficientFundsAtomicity()
        {
          try
          {
            source.TransferFunds(destination, 400m);
          }
          catch (InsufficientFundsException expected)
          {
          }

          Assert.AreEqual(350m, source.Balance);
          Assert.AreEqual(200m, destination.Balance);
        }
    }
}
