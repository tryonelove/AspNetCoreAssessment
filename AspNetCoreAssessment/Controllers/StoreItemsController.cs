using System.Collections.Generic;
using System.Linq;
using AspNetCoreAssessment.Filters;
using AspNetCoreAssessment.Foundation.Interfaces;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    public class StoreItemsController : ApiController
    {
        private readonly IStoreItemsService _storeItemsService;


        public StoreItemsController(IStoreItemsService itemsService)
        {
            _storeItemsService = itemsService;
        }


        [HttpGet]
        public IReadOnlyCollection<Item> GetAll()
        {
            var serviceItems = _storeItemsService.GetAll();
            var items = serviceItems.Select(CreateFrom).ToList();

            return items;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ServiceFilter(typeof(SpecificIdFilter))]
        public Item GetById(int id)
        {
            var serviceItem = _storeItemsService.GetById(id);
            var item = CreateFrom(serviceItem);

            return item;
        }

        [HttpPost]
        public Item Add(Item item)
        {
            if (!ModelState.IsValid)
            {
                return new Item();
            }

            var serviceItem = CreateFrom(item);
            _storeItemsService.Add(serviceItem);

            return item;
        }


        private static Item CreateFrom(Foundation.Models.StoreItem item)
        {
            return new()
            {
                Id = item.Id,
                Title = item.Title,
                Price = item.Price
            };
        }

        private static Foundation.Models.StoreItem CreateFrom(Item item)
        {
            return new()
            {
                Id = item.Id,
                Title = item.Title,
                Price = item.Price
            };
        }
    }
}