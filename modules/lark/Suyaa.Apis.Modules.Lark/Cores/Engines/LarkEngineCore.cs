using Egg.Lark;
using Suyaa.Apis.Modules.Base.Entities.Users;
using Suyaa.Apis.Modules.Lark.Cores.Engines.Stos;
using Suyaa.Microservice.Results;
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
    public class LarkEngineCore : ILarkEngineCore
    {
        /// <summary>
        /// 运行Lark脚本
        /// </summary>
        /// <returns></returns>
        public async Task<string> Run(LarkEngineRunInput input)
        {
            var func = ScriptParser.Parse(input.Script);
            using (LarkEngineFunctions funcs = new LarkEngineFunctions())
            {
                funcs.Reg<LarkEngineFunctionRegistr>();
                using (Egg.Lark.ScriptEngine engine = new Egg.Lark.ScriptEngine(func, funcs))
                {
                    var obj = engine.Execute();
                    return await Task.FromResult(obj is string ? (string)obj : "");
                }
            }
        }
    }
}
