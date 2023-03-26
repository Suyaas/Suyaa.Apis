using Egg.Lark;

namespace Suyaa.Apis.Plugs.Common
{
    /// <summary>
    /// 公共函数集合
    /// </summary>
    public class CommonFunction: ScriptFunctionRegistrBase
    {
        /// <summary>
        /// 插件测试
        /// </summary>
        /// <returns></returns>
        [Func]
        public string PlugTest()
        {
            return "plug test ok";
        }
    }
}