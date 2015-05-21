using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.CartShopTest
{
    public interface IProductRepository
    {
        Product GetById(int id);
    }
}
