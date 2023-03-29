using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Cores.Jwt.Stos
{
    /// <summary>
    /// Jwt信息入参
    /// </summary>
    public class JwtInfoInput
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual string UserId { get; set; } = string.Empty;
    }
}
