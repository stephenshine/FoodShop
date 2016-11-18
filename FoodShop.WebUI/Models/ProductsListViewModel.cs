using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShop.Domain.Entities;

namespace FoodShop.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}