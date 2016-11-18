using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShop.Domain.Entities;

namespace FoodShop.Domain.Abstract
{
    class IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
