using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Suyaa.Apis.Attributes;
using Suyaa.Apis.Dependency;
using Suyaa.Apis.User.Apps.Authorize.Sto;
using Suyaa.Apis.User.Apps.Jwt.Dto;
using Suyaa.Apis.User.Cores.Jwt;
using Suyaa.Apis.User.Cores.Jwt.Dtos;
using Suyaa.Apis.User.Cores.Jwt.Stos;
using Suyaa.Microservice.Dependency;
using Suyaa.Microservice.Exceptions;
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
    public class AuthorizeApp : ControllerBase, IServiceApp
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

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="FriendlyException"></exception>
        [Post]
        public async Task<JwtOutput> Login([FromBody] AuthorizeLoginInput input)
        {
            string token = await _jwtCore.GenerateToken(new JwtInfoInput()
            {
                UserId = input.UserId,
                UserLoginId = input.UserLoginId,
            });
            return new JwtOutput
            {
                Token = token,
                RenewalTime = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds()
            };
        }

        /// <summary>
        /// 验证Token登录
        /// </summary>
        /// <returns></returns>
        [Get]
        [JwtAuthorize]
        public async Task<JwtInfoOutput> Verify()
        {
            var info = (JwtInfo?)this.RouteData.Values[JwtInfo.ROUTER_KEY];
            if (info is null) throw new FriendlyException($"信息获取失败");
            JwtInfoOutput output = new JwtInfoOutput()
            {
                UserId = info.UserId,
                UserLoginId = info.UserLoginId,
            };
            return await Task.FromResult(output);
        }

    }
}
