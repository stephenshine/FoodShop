using System;
using System.Collections.Generic;
using System.Data.Entity;
using FoodShop.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
