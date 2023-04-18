using Microsoft.IdentityModel.Tokens;
using Suyaa.Apis.Attributes;
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
        public async Task<JwtOutput> Create()
        {
            string token = await _jwtCore.GenerateToken(new JwtInfoInput());
            return new JwtOutput
            {
                Token = token,
                RenewalTime = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds()
            };
        }

        /// <summary>
        /// 续订Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Get]
        public async Task<JwtOutput> Renewal(string token)
        {
            string tokenNew;
            try
            {
                var output = await _jwtCore.ReadToken(token);
                tokenNew = await _jwtCore.GenerateToken(new JwtInfoInput()
                {
                    UserId = output.UserId,
                });
            }
            catch
            {
                tokenNew = await _jwtCore.GenerateToken(new JwtInfoInput());
            }
            return new JwtOutput
            {
                Token = tokenNew,
                RenewalTime = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds()
            };
        }

        /// <summary>
        /// 验证Token登录
        /// </summary>
        /// <returns></returns>
        [Get]
        [JwtAuthorize]
        public async Task Verify()
        {
            await Task.CompletedTask;
        }
    }
}
