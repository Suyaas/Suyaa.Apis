using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// 用户
        /// </summary>
        public UserController(
            )
        {
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        public async Task<string> GetInfo()
        {
            
            return "User";
        }
    }
}
