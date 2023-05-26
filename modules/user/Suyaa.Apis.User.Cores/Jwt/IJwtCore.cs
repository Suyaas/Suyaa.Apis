using Suyaa.Apis.User.Cores.Jwt.Dtos;
using Suyaa.Apis.User.Cores.Jwt.Stos;
using Suyaa.Hosting.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Cores.Jwt
{
    /// <summary>
    /// Jwt
    /// </summary>
    public interface IJwtCore : IServiceCore
    {
        /// <summary>
        /// 生成一个新的Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<string> GenerateToken(JwtInfoInput input);

        /// <summary>
        /// 读取Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<JwtInfoOutput> ReadToken(string token);
    }
}
