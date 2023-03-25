using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Microservice.Exceptions;

namespace Suyaa.Apis.Services.ApiManager
{
    /// <summary>
    /// Api管理器
    /// </summary>
    public class ApiManager : IApiManager
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; private set; } = string.Empty;

        /// <summary>
        /// 设置路径
        /// </summary>
        /// <param name="path"></param>
        public void SetPath(string path)
        {
            this.Path = path;
        }
    }
}
