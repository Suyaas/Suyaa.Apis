using Suyaa.Script;
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
    public class LarkEngineCore : ILarkEngineCore
    {
        // 脚本函数集合
        private readonly ScriptFunctions _scriptFunctions;

        /// <summary>
        /// Lark脚本引擎
        /// </summary>
        public LarkEngineCore()
        {
            _scriptFunctions = new ScriptFunctions();
            _scriptFunctions.Reg<Plugs.Common.CommonRegistr>();
        }

        /// <summary>
        /// 脚本函数
        /// </summary>
        public ScriptFunctions ScriptFunctions => _scriptFunctions;

    }
}
