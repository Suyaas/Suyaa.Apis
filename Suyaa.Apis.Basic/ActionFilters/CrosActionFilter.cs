using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Basic.ActionFilters
{
    public class CrosActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
            var request = context.HttpContext.Request;
            sy.Logger.Info(request.Method);
        }
    }
}
