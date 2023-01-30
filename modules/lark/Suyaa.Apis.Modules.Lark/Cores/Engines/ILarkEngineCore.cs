using Suyaa.Apis.Modules.Lark.Cores.Engines.Stos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Modules.Lark.Cores.Engines
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public interface ILarkEngineCore
    {
        /// <summary>
        /// 运行Lark脚本
        /// </summary>
        /// <returns></returns>
        Task<string> Run(LarkEngineRunInput input);
    }
}
