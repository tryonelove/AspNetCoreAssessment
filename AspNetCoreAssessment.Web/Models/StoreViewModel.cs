using System.Collections.Generic;

namespace AspNetCoreAssessment.Web.Models
{
    public class StoreViewModel
    {
        public IReadOnlyCollection<ProductViewModel> Products { get; set; }
    }
}