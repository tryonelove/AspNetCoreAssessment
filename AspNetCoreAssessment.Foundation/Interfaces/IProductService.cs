using System.Collections.Generic;
using AspNetCoreAssessment.Foundation.Models;

namespace AspNetCoreAssessment.Foundation.Interfaces
{
    public interface IProductService
    {
        IReadOnlyCollection<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);
    }
}