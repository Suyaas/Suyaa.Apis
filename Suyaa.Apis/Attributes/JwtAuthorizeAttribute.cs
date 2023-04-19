using Microsoft.AspNetCore.Mvc.Filters;
using Suyaa.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Microservice.Exceptions;
using Suyaa.Apis.Dependency;

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
            // 检测头部信息
            var request = context.HttpContext.Request;
            if (!request.Headers.ContainsKey(KEY_TOKEN)) throw new FriendlyException($"授权无效");
            string token = request.Headers[KEY_TOKEN].ToString();
            // 检测Jwt信息
            var info = token.GetJwtInfo();
            if (info.UserId <= 0) throw new FriendlyException($"授权无效");
            // 填充信息
            context.RouteData.Values[JwtInfo.ROUTER_KEY] = info;
            base.OnActionExecuting(context);
        }
    }
}
