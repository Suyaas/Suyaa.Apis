using Suyaa.Apis.Services.LarkScriptFunctions;
using Suyaa.Microservice.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Lark.Apps.Engine
{
    /// <summary>
    /// 脚本引擎
    /// </summary>
    [App("Lark/Engine")]
    public class EngineApp : ServiceApp
    {
        private readonly ILarkEngineCore _larkEngineCore;

        /// <summary>
        /// 脚本引擎
        /// </summary>
        public EngineApp(
            ILarkEngineCore larkEngineCore
            )
        {
            _larkEngineCore = larkEngineCore;
        }

        /// <summary>
        /// 获取函数信息
        /// </summary>
        /// <returns></returns>
        [Get]
        public async Task<List<string>> GetFunctions()
        {
            var names = _larkEngineCore.ScriptFunctions.Select(d => d.Key).ToList();
            return await Task.FromResult(names);
        }
    }
}
