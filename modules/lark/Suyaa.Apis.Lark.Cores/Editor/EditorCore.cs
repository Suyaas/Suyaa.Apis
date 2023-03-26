using Suyaa.Apis.Services.ApiManager;
using Suyaa.Microservice.Exceptions;
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
    public class EditorCore : IEditorCore
    {
        private readonly IApiManager _apiManager;

        /// <summary>
        /// 编辑器
        /// </summary>
        public EditorCore(
            IApiManager apiManager
            )
        {
            _apiManager = apiManager;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        /// <exception cref="FriendlyException"></exception>
        public async Task SaveFileContent(string path, string content, bool create = false)
        {
            string fullPath = egg.IO.CombinePath(_apiManager.Path, path + ".lark");
            if (create && egg.IO.FileExists(fullPath))
                throw new FriendlyException($"文件'{path}'已存在");
            egg.IO.WriteUtf8FileContent(fullPath, content);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<string> GetFileContent(string path)
        {
            string fullPath = egg.IO.CombinePath(_apiManager.Path, path + ".lark");
            if (!egg.IO.FileExists(fullPath)) throw new FriendlyException($"文件'{path}'不存在");
            return await Task.FromResult(egg.IO.ReadUtf8FileContent(fullPath));
        }
    }
}
