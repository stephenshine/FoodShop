using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FoodShop.Domain.Abstract;
using FoodShop.Domain.Entities;
using FoodShop.WebUI.Controllers;
using Moq;

namespace FoodShop.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Paging()
        {
            // Arrange
            #region
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" },
                new Product { ProductID = 6, Name = "P6" },
                new Product { ProductID = 7, Name = "P7" },
                new Product { ProductID = 8, Name = "P8" },
            });

            ProductController controller = new ProductController(mock.Object);
            #endregion

            // Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.Index(2).Model;

            // Assert
            Product[] products = result.ToArray();
            Assert.IsTrue(products.Length == 3);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
            Assert.AreEqual(products[2].Name, "P6");
        }
    }
}
