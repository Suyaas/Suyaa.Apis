using Microsoft.IdentityModel.Tokens;
using Suyaa.Apis.User.Apps.Jwt.Dto;
using Suyaa.Apis.User.Cores.Jwt;
using Suyaa.Apis.User.Cores.Jwt.Stos;
using Suyaa.Microservice.Dependency;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Apps.User
{
    /// <summary>
    /// 授权
    /// </summary>
    [App("User/Authorize")]
    public class AuthorizeApp : ServiceApp
    {
        private readonly IJwtCore _jwtCore;

        /// <summary>
        /// 授权
        /// </summary>
        public AuthorizeApp(
            IJwtCore jwtCore
            )
        {
            _jwtCore = jwtCore;
        }

    }
}
