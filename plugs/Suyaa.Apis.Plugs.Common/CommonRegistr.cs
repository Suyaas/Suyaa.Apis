using Microsoft.Extensions.DependencyInjection;
using Suyaa.Apis.Services.ApiManager;
using Suyaa.Script;

namespace Suyaa.Apis.Plugs.Common
{
    /// <summary>
    /// 公共函数集合
    /// </summary>
    public class CommonRegistr : ScriptRegistrBase
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

        /// <summary>
        /// 插件容器测试
        /// </summary>
        /// <returns></returns>
        [Func]
        public string ApiPath()
        {
            var provider = this.Engine.TakeRequired<IServiceProvider>();
            IApiManager apiManager = provider.GetRequiredService<IApiManager>();
            return apiManager.Path;
        }
    }
}