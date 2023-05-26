using Suyaa.Script;
using Suyaa.Hosting.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Services.LarkScriptFunctions
{
    /// <summary>
    /// Lark脚本引擎
    /// </summary>
    public interface ILarkEngineCore : IServiceCore
    {
        /// <summary>
        /// 脚本函数
        /// </summary>
        ScriptFunctions ScriptFunctions { get; }
    }
}
