using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShop.Domain.Abstract;
using FoodShop.Domain.Entities;

namespace FoodShop.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
