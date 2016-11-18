using FoodShop.Domain.Abstract;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        #region
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        #endregion

        public int PageSize = 3;
        public ViewResult Index(int page = 1)
        {
            var data = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            return View(data);
        }
    }
}