using AspNetCoreAssessment.Web.Validators;

namespace AspNetCoreAssessment.Web.Models
{
    public class ProductViewModel
    {
        [MinValue(5)]
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
    }
}