using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suyaa.Apis.Base.Cores.Users;
using Suyaa.Hosting.Attributes;
using Suyaa.Hosting.Dependency;
using Suyaa.Hosting.Results;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Base.Apps.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [App("Users/UserInfo")]
    public class UserInfoApp : ServiceApp
    {

        private readonly IUserInfoCore _userInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserInfoApp(
            IUserInfoCore userInfoCore
            )
        {
            _userInfoCore = userInfoCore;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        public async Task<ApiResult<string>> GetInfo()
        {
            return await _userInfoCore.GetInfo();
        }
    }
}
