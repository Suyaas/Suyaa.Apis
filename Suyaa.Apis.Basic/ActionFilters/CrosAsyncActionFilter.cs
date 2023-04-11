using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Basic.ActionFilters
{
    public class CrosAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            var request = context.HttpContext.Request;
            sy.Logger.Info(request.Method);
            await next();
        }
    }
}
