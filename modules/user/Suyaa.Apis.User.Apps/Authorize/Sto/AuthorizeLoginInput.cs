using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Apps.Authorize.Sto
{
    /// <summary>
    /// 登录入参
    /// </summary>
    public class AuthorizeLoginInput
    {
        public virtual long UserId { get; set; } = 0;
        public virtual string UserLoginId { get; set; } = string.Empty;
    }
}
