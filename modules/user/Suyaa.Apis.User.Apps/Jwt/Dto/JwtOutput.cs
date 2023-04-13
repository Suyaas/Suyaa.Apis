using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Apps.Jwt.Dto
{
    /// <summary>
    /// Jwt出参
    /// </summary>
    public class JwtOutput
    {
        /// <summary>
        /// Jwt令牌
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 续订时间
        /// </summary>
        public long RenewalTime { get; set; } = 0;
    }
}
