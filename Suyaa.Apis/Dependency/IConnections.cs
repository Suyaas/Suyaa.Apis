using Suyaa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Dependency
{
    /// <summary>
    /// 系统连接
    /// </summary>
    public interface IConnections
    {
        /// <summary>
        /// 根据绑定类型获取连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IDatabaseConnection FindConnection<T>();
    }
}
