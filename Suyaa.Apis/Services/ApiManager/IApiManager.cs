using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Services.ApiManager
{
    public interface IApiManager
    {
        /// <summary>
        /// 存储路径
        /// </summary>
        public string Path { get; }
    }
}
