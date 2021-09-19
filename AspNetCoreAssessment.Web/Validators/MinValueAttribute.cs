using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AspNetCoreAssessment.Web.Validators
{
    public class MinValueAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _min;


        public MinValueAttribute(int min)
        {
            _min = min;
        }


        public override bool IsValid(object? value)
        {
            var stringNumber = value?.ToString();
            var number = int.Parse(stringNumber);

            return number >= _min;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val-minvalue-value", "5");
            MergeAttribute(context.Attributes, "data-val-minvalue", $"Min value is {_min}");
        }


        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);

            return true;
        }
    }
}