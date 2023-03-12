using Suyaa.Apis.Common.Apps.Assemblies.Dtos;
using Suyaa.Microservice.Dependency;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Common.Apps.Assemblies
{
    /// <summary>
    /// 产品
    /// </summary>
    [App("Common/Product")]
    public class ProductApp : ServiceApp
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        [Get]
        public AssemblyOutput GetInfo()
        {
            return new AssemblyOutput()
            {
                Name = egg.Assembly.Name,
                Version = egg.Assembly.Version,
            };
        }
    }
}
