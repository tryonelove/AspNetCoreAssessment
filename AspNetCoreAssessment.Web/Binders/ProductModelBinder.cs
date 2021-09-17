using System;
using System.Threading.Tasks;
using AspNetCoreAssessment.Foundation.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreAssessment.Web.Binders
{
    public class ProductModelBinder : IModelBinder
    {
        private readonly IProductService _productService;


        public ProductModelBinder(IProductService productService)
        {
            _productService = productService;
        }


        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult  = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (!int.TryParse(value, out var id))
            {
                bindingContext.ModelState.TryAddModelError(modelName, "ProductId must be an integer");

                return Task.CompletedTask;
            }

            var product = _productService.GetById(id);

            bindingContext.Result = ModelBindingResult.Success(product);

            return Task.CompletedTask;
        }
    }
}