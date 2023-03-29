using Microsoft.IdentityModel.Tokens;
using Suyaa.Apis.User.Cores.Jwt.Dtos;
using Suyaa.Apis.User.Cores.Jwt.Stos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Microservice.Exceptions;

namespace Suyaa.Apis.User.Cores.Jwt
{
    /// <summary>
    /// Jwt
    /// </summary>
    public class JwtCore : IJwtCore
    {
        /// <summary>
        /// 生成一个新的Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> GenerateToken(JwtInfoInput input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.JWT_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(nameof(input.UserId), input.UserId) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

        /// <summary>
        /// 读取Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<JwtInfoOutput> ReadToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.JWT_KEY);
            // 检验Token
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);
            var jwt = (JwtSecurityToken)validatedToken;
            if (jwt is null) throw new FriendlyException("jwt信息无效");
            JwtInfoOutput output = new JwtInfoOutput();
            //读取信息
            foreach (var claim in jwt.Claims)
            {
                switch (claim.Type)
                {
                    case nameof(output.UserId):
                        output.UserId = claim.Value;
                        break;
                }
            }
            return await Task.FromResult(output);
        }
    }
}
