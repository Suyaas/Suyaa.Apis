using Suyaa.Microservice.Dependency;
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
        /// 获取文件内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<string> GetFileContent(string path);
    }
}
