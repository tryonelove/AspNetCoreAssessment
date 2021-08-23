using System.ComponentModel.DataAnnotations;
using AspNetCoreAssessment.Models.Validators;

namespace AspNetCoreAssessment.Models
{
    public class Item
    {
        [Required]
        [Range(1,10)]
        public int Id { get; set; }

        [AllowedTitle(new []{ "Fanta", "Water" })]
        public string Title { get; set; }

        public double Price { get; set; }
    }
}