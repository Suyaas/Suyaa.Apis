using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.UI.Middlewares.Dto
{
    /// <summary>
    /// UI中间件数据
    /// </summary>
    public class UIMiddlewareDto
    {
        /// <summary>
        /// 操作路径
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// 是否支持Vue路由
        /// </summary>
        public bool IsVueRouter { get; set; } = false;
    }
}
