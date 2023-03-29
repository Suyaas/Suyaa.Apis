using Microsoft.IdentityModel.Tokens;
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

namespace Suyaa.Apis.User.Apps.Jwt
{
    /// <summary>
    /// Jwt
    /// </summary>
    [App("User/Jwt")]
    public class JwtApp : ServiceApp
    {
        private readonly IJwtCore _jwtCore;

        /// <summary>
        /// Jwt
        /// </summary>
        public JwtApp(
            IJwtCore jwtCore
            )
        {
            _jwtCore = jwtCore;
        }

        /// <summary>
        /// 生成一个新的Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Get]
        public async Task<string> Create()
        {
            return await _jwtCore.GenerateToken(new JwtInfoInput());
        }

        /// <summary>
        /// 续订Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Get]
        public async Task<string> Renewal(string token)
        {
            var output = await _jwtCore.ReadToken(token);
            return await _jwtCore.GenerateToken(new JwtInfoInput()
            {
                UserId = output.UserId,
            });
        }
    }
}
