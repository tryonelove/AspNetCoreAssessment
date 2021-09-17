using System;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace AspNetCoreAssessment.Web.Validators
{
    public class MinValueAttributeAdapter : AttributeAdapterBase<MinValueAttribute>
    {
        public MinValueAttributeAdapter(MinValueAttribute attribute, IStringLocalizer? stringLocalizer)
            : base(attribute, stringLocalizer)
        {

        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val-minvalue-value", "5");
            MergeAttribute(context.Attributes, "data-val-minvalue", GetErrorMessage(context));
        }
    }
}