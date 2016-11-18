using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using FoodShop.Domain.Abstract;
using FoodShop.Domain.Entities;

namespace FoodShop.WebUI.Infrastructure
{
    public class NinjectDR : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDR(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns
                ( new List<Product>
                {
                    new Product { Name = "Apple", Price = 0.79m },
                    new Product { Name = "Banana", Price = 0.59m },
                    new Product { Name = "Carrot", Price = 0.35m }
                }
                );

            // every instance of IProductRepository will be replaced by the mock data above
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}