using System.Collections.Generic;
using System.Linq;
using AspNetCoreAssessment.Foundation.Interfaces;
using AspNetCoreAssessment.Foundation.Models;

namespace AspNetCoreAssessment.Foundation.Services
{
    public class StoreItemsService : IStoreItemsService
    {
        private readonly ICollection<StoreItem> _items = new List<StoreItem>
        {
            new StoreItem { Id = 1, Title = "Coca-Cola", Price = 4.99d },
            new StoreItem { Id = 2, Title = "Pizza", Price = 9.99d },
            new StoreItem { Id = 3, Title = "Laptop", Price = 999.99d },
            new StoreItem { Id = 4, Title = "Postcard", Price = 0.99d },
        };


        public IReadOnlyCollection<StoreItem> GetAll()
        {
            return _items.ToList();
        }

        public StoreItem GetById(int id)
        {
            var item = _items.SingleOrDefault(i => i.Id == id);

            return item ?? _items.First();
        }

        public void Add(StoreItem item)
        {
            _items.Add(item);
        }
    }
}