using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace UnitTest.CartShopTest
{
    [TestFixture]
    public class CartTest
    {
        Mock<IProductRepository> mockRepo;
        IProductRepository productRepository;
        Cart cart;

        [SetUp]
        public void Init()
        {
            //init mock and class obj
            mockRepo = new Mock<IProductRepository>();
            cart = new Cart();

            //set up behavior
            mockRepo.Setup(m => m.GetById(1)).Returns(new Product { Id = 1, Name = "Tomato", Price = 15 });
            mockRepo.Setup(m => m.GetById(2)).Returns(new Product { Id = 2, Name = "Apple", Price = 20 });
            mockRepo.Setup(m => m.GetById(3)).Returns(new Product { Id = 3, Name = "Carrot", Price = 30 });
            mockRepo.Setup(m => m.GetById(4)).Returns(new Product { Id = 4, Name = "Banana", Price = 10 });

            //init repo obj
            productRepository = mockRepo.Object;
        }

        [Test]
        public void AddProductTest()
        {
            cart.AddProduct(productRepository.GetById(1));

            Assert.AreEqual(productRepository.GetById(1), cart.GetProductById(1));
            Assert.AreEqual(1, cart.CountProduct);
        }

        [Test]
        public void DeleteProductTest()
        {
            Assert.AreEqual(0, cart.CountProduct);
            cart.AddProduct(productRepository.GetById(1));
            Assert.AreEqual(1, cart.CountProduct);
            cart.RemoveProduct(productRepository.GetById(1));
            Assert.AreEqual(0, cart.CountProduct);
        }

        [Test]
        public void TotalPriceTest()
        {
            cart.AddProduct(productRepository.GetById(1));
            cart.AddProduct(productRepository.GetById(2));
            cart.AddProduct(productRepository.GetById(3));
            cart.AddProduct(productRepository.GetById(4));

            Assert.AreEqual(75, cart.GetTotalPrice());
        }

        [Test]
        public void CountProductTest()
        {
            cart.AddProduct(productRepository.GetById(1));
            cart.AddProduct(productRepository.GetById(2));
            cart.AddProduct(productRepository.GetById(3));
            cart.AddProduct(productRepository.GetById(3));

            Assert.AreEqual(4, cart.CountProduct);
        }

        [Test]
        public void MainTest()
        {
            Assert.AreEqual(0, cart.CountProduct);

            cart.AddProduct(productRepository.GetById(1));
            cart.AddProduct(productRepository.GetById(2));
            cart.AddProduct(productRepository.GetById(3));
            cart.AddProduct(productRepository.GetById(3));
            cart.AddProduct(productRepository.GetById(4));
            cart.AddProduct(productRepository.GetById(4));

            Assert.AreEqual(6, cart.CountProduct);
            Assert.AreEqual(115, cart.GetTotalPrice());

            cart.RemoveProduct(productRepository.GetById(1));

            Assert.AreEqual(5, cart.CountProduct);
            Assert.AreEqual(100, cart.GetTotalPrice());
        }
    }
}
