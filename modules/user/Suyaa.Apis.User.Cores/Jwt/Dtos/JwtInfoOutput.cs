using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Cores.Jwt.Dtos
{
    /// <summary>
    /// Jwt信息出参
    /// </summary>
    public class JwtInfoOutput
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual string UserId { get; set; } = string.Empty;
    }
}
