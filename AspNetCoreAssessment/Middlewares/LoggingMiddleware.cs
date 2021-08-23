using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAssessment.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;


        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Started logging");
            await next(context);
            _logger.LogInformation("Stopped logging");
        }
    }
}