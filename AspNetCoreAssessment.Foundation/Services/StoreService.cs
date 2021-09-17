using System.Collections.Generic;
using System.Linq;
using AspNetCoreAssessment.Foundation.Interfaces;
using AspNetCoreAssessment.Foundation.Models;

namespace AspNetCoreAssessment.Foundation.Services
{
    public class ProductService : IProductService
    {
        private static readonly ICollection<Product> Items = new List<Product>
        {
            new Product { Id = 1, Title = "Coca-Cola", Price = 4.99M },
            new Product { Id = 2, Title = "Pizza", Price = 9.99M },
            new Product { Id = 3, Title = "Laptop", Price = 999.99M },
            new Product { Id = 4, Title = "Postcard", Price = 0.99M },
        };


        public IReadOnlyCollection<Product> GetAll()
        {
            return Items.ToList();
        }

        public Product GetById(int id)
        {
            var item = Items.SingleOrDefault(i => i.Id == id) ?? Items.First();

            return item;
        }

        public void Add(Product item)
        {
            Items.Add(item);
        }
    }
}