using System.Collections.Generic;
using AspNetCoreAssessment.Foundation.Models;

namespace AspNetCoreAssessment.Foundation.Interfaces
{
    public interface IStoreItemsService
    {
        IReadOnlyCollection<StoreItem> GetAll();

        StoreItem GetById(int id);

        void Add(StoreItem item);
    }
}