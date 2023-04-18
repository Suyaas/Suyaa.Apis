using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.UI.Options
{
    /// <summary>
    /// 界面配置
    /// </summary>
    public class UIOptions
    {
        /// <summary>
        /// 操作路径
        /// </summary>
        public List<UIPathOption> Paths { get; set; }

        /// <summary>
        /// 404页面
        /// </summary>
        public string Page404 { get; set; } = string.Empty;

        /// <summary>
        /// 是否支持Vue路由
        /// </summary>
        public bool IsVueRouter { get; set; } = false;

        /// <summary>
        /// 添加路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public UIOptions AddPath(string path)
        {
            this.Paths.Add(new UIPathOption()
            {
                Path = path,
                UrlPath = $"/{path}/",
            });
            return this;
        }

        /// <summary>
        /// 添加路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public UIOptions AddPath(string path, string url)
        {
            if (!url.StartsWith('/')) url = "/" + url;
            if (!url.EndsWith('/')) url += "/";
            this.Paths.Add(new UIPathOption()
            {
                Path = path,
                UrlPath = url,
            });
            return this;
        }

        /// <summary>
        /// 界面配置
        /// </summary>
        public UIOptions()
        {
            this.Paths = new List<UIPathOption>();
        }
    }

    /// <summary>
    /// 界面配置路径配置
    /// </summary>
    public class UIPathOption
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// 地址路径
        /// </summary>
        public string UrlPath { get; set; } = string.Empty;
    }
}
