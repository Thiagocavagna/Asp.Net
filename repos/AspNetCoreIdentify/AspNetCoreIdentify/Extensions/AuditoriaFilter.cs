using KissLog;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Extensions;


namespace AspNetCoreIdentity.Extensions
{
    public class AuditoriaFilter : IActionFilter
    {
        private readonly IKLogger _logger;

        public AuditoriaFilter(IKLogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                var msg = context.HttpContext.User.Identity.Name
                    + "Acessou: "
                    + context.HttpContext.Request.GetDisplayUrl();
                
                _logger.Info(msg);
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
