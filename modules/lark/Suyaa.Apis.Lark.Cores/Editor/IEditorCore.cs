using Suyaa.Hosting.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Lark.Cores.Editor
{
    /// <summary>
    /// 编辑器
    /// </summary>
    public interface IEditorCore : IServiceCore
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">内容</param>
        /// <param name="create">是否创建</param>
        /// <returns></returns>
        Task SaveFileContent(string path, string content, bool create = false);

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        Task<string> GetFileContent(string path);
    }
}
