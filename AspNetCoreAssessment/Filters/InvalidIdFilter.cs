using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreAssessment.Filters
{
    public class SpecificIdFilter : Attribute, IAsyncActionFilter
    {
        private readonly int _id;


        public SpecificIdFilter(int id)
        {
            _id = id;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments["id"].Equals(_id))
            {
                context.ActionArguments["id"] = 2;
            }

            await next();
        }
    }
}