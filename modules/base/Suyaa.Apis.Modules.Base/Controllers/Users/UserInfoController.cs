using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suyaa.Apis.Modules.Base.Cores.Users;
using Suyaa.Microservice.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Modules.Base.Controllers.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [ApiController]
    [Route("Users/[controller]")]
    public class UserInfoController : ControllerBase
    {

        private readonly IUserInfoCore _userInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserInfoController(
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
