using System;
using AspNetCoreAssessment.Foundation.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCoreAssessment.Web.Binders
{
    public class ProductModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Product))
            {
                return new BinderTypeModelBinder(typeof(ProductModelBinder));
            }

            return null;
        }
    }
}