using Microsoft.IdentityModel.Tokens;
using Suyaa.Apis.Dependency;
using Suyaa;
using Suyaa.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Helpers
{
    /// <summary>
    /// 字符串助手类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 转化为小写数据库专用名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLowerDatabaseName(this string? str)
        {
            if (str is null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(str[0].ToString().ToLower());
            for (int i = 1; i < str.Length; i++)
            {
                char chr = str[i];
                if (chr >= 'A' && chr <= 'Z')
                {
                    sb.Append('_');
                    sb.Append(str[0].ToString().ToLower());
                }
                else
                {
                    sb.Append(chr);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 读取Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static JwtInfo GetJwtInfo(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtInfo.JWT_KEY);
            JwtSecurityToken jwt;
            // 检验Token
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);
                jwt = (JwtSecurityToken)validatedToken;
            }
            catch
            {
                throw new HostFriendlyException($"Jwt信息无效");
            }
            if (jwt is null) throw new HostFriendlyException("Jwt信息无效");
            JwtInfo info = new JwtInfo();
            //读取信息
            foreach (var claim in jwt.Claims)
            {
                switch (claim.Type)
                {
                    // 登录用户
                    case nameof(info.UserId):
                        info.UserId = claim.Value.ToLong();
                        break;
                    // 登录用户
                    case nameof(info.UserLoginId):
                        info.UserLoginId = claim.Value;
                        break;
                }
            }
            return info;
        }
    }
}
