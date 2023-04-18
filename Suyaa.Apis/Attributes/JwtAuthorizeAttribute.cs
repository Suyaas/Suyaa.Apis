using Microsoft.AspNetCore.Mvc.Filters;
using Suyaa.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Microservice.Exceptions;

namespace Suyaa.Apis.Attributes
{
    /// <summary>
    /// Jwt登录校验
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class JwtAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 令牌名称
        /// </summary>
        private const string KEY_TOKEN = "Suyaa-Token";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            if (!request.Headers.ContainsKey(KEY_TOKEN)) throw new FriendlyException($"");

            base.OnActionExecuting(context);
        }
    }
}
