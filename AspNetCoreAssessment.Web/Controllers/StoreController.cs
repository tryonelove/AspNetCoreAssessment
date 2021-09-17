using System.Collections.Generic;
using System.Linq;
using AspNetCoreAssessment.Foundation.Interfaces;
using AspNetCoreAssessment.Foundation.Models;
using AspNetCoreAssessment.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Web.Controllers
{
    [Route("store")]
    public class StoreController : Controller
    {
        private readonly IProductService _productService;


        public StoreController(IProductService productsService)
        {
            _productService = productsService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetAll();

            var productsViewModels = products.Select(CreateFrom).ToList();
            var storeViewModel = new StoreViewModel { Products = productsViewModels };

            return View(storeViewModel);
        }

        [HttpGet]
        [Route("products/{id:int}")]
        public IActionResult Index(int id)
        {
            var product = _productService.GetById(id);

            var productViewModel = CreateFrom(product);

            return View("Product", productViewModel);
        }

        [HttpGet]
        [Route("products/create")]
        public IActionResult CreateProduct()
        {
            return View("CreateProduct");
        }

        [HttpPost]
        [Route("products/create")]
        public IActionResult CreateProduct(ProductViewModel productViewModel)
        {
            if (productViewModel is null)
            {
                return View("CreateProduct");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error while validating the model");

                return View("CreateProduct");
            }

            var product = CreateFrom(productViewModel);
            _productService.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("products")]
        public IActionResult GetById([ModelBinder(Name = "id")] Product product)
        {
            if (product is null)
            {
                return View("Product");
            }

            var productViewModel = CreateFrom(product);

            return View("Product", productViewModel);
        }


        private ProductViewModel CreateFrom([FromQuery] Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price
            };
        }

        private static Product CreateFrom(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price
            };
        }

        private static StoreViewModel CreateFrom(IReadOnlyCollection<ProductViewModel> products)
        {
            return new StoreViewModel
            {
                Products = products
            };
        }

        private Product CreateFrom(int id, string title, decimal price)
        {
            return new Product
            {
                Id = id,
                Title = title,
                Price = price
            };
        }
    }
}