using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.CartShopTest
{
    public class Cart
    {
        private List<Product> _myCart;

        public Cart()
        {
            _myCart = new List<Product>();
        }

        public Product GetProductById(int Id)
        {
            return _myCart.SingleOrDefault(p => p.Id == Id);
        }

        public void AddProduct(Product p)
        {
            _myCart.Add(p);
        }

        public void RemoveProduct(Product p)
        {
            _myCart.Remove(p);
        }

        public int CountProduct 
        { 
            get 
            { 
                return _myCart.Count; 
            } 
        }

        public decimal GetTotalPrice()
        {
            return _myCart.Sum(p => p.Price);
        }
    }
}
