using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Common.Apps.Assemblies.Dtos
{
    /// <summary>
    /// 程序集输出对象
    /// </summary>
    public class AssemblyOutput
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;
        /// <summary>
        /// 版本
        /// </summary>
        public virtual string Version { get; set; } = string.Empty;
    }
}
