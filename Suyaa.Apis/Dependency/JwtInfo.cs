using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Dependency
{
    /// <summary>
    /// Jwt信息
    /// </summary>
    public class JwtInfo
    {
        /// <summary>
        /// JWT密钥
        /// </summary>
        public const string JWT_KEY = "0b26efe2c64e4eb8ae8e97384935cb2c";

        /// <summary>
        /// JWT路由名称
        /// </summary>
        public const string ROUTER_KEY = "Jwt-Info";

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; } = 0;

        /// <summary>
        /// 用户登录Id
        /// </summary>
        public string UserLoginId { get; set; } = string.Empty;
    }
}
