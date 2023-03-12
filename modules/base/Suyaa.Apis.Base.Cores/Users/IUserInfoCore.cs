using Suyaa.Microservice.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Base.Cores.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public interface IUserInfoCore : IServiceCore
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        Task<string> GetInfo();
    }
}
