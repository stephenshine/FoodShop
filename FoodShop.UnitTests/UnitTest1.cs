using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodShop.Domain.Abstract;
using FoodShop.Domain.Entities;
using FoodShop.WebUI.Controllers;
using FoodShop.WebUI.Models;
using FoodShop.WebUI.HtmlHelpers;
using Moq;

namespace FoodShop.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        // Arrange Mock repo

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
            ProductsListViewModel result = (ProductsListViewModel)controller.Index(2).Model;

            // Assert
            Product[] products = result.Products.ToArray();
            Assert.IsTrue(products.Length == 3);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
            Assert.AreEqual(products[2].Name, "P6");
        }

        [TestMethod]
        public void PagingLinks()
        {
            // Arrange
            #region
            // Arrange helper
            HtmlHelper helper = null;

            // Arrange paging data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 25,
                ItemsPerPage = 10
            };

            // Arrange delegate
            Func<int, string> pageURLDelegate = i => "Page" + i;
            #endregion

            // Act
            MvcHtmlString result = helper.PageLinks(pagingInfo, pageURLDelegate);

            // Assert
            // @ symbol and double " replace single so c# can interpret literal strings
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void PagingViewModel()
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
            controller.PageSize = 3;
            #endregion

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.Index(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 8);
            Assert.AreEqual(pageInfo.TotalPages, 3);

        }
    }
}
