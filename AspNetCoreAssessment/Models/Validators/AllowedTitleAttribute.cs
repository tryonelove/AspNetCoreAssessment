using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetCoreAssessment.Models.Validators
{
    public class AllowedTitleAttribute : ValidationAttribute
    {
        private readonly IReadOnlyCollection<string> _allowedTitles;


        public AllowedTitleAttribute(string[] allowedTitles)
        {
            _allowedTitles = allowedTitles;

            ErrorMessage = "Invalid range has been provided.";
        }


        public override bool IsValid(object? value)
        {
            var title = value?.ToString();
            if (title is null)
            {
                return false;
            }

            return _allowedTitles.Contains(title);
        }
    }
}