using Suyaa.Apis.Modules.Base.Entities.Users;
using Suyaa.Microservice.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Modules.Base.Cores.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoCore : IUserInfoCore
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetInfo()
        {
            await Task.Delay(1);
            return "UserInfoCore";
        }
    }
}
