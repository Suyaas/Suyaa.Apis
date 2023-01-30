using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suyaa.Apis.Modules.Base.Cores.Users;
using Suyaa.Apis.Modules.Lark.Cores.Engines;
using Suyaa.Apis.Modules.Lark.Cores.Engines.Stos;
using Suyaa.Microservice.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Modules.Lark.Controllers.Engines
{
    /// <summary>
    /// 百灵鸟引擎
    /// </summary>
    [ApiController]
    [Route("Engines/[controller]")]
    public class LarkEngineController : ControllerBase
    {

        private readonly ILarkEngineCore _larkEngineCore;

        /// <summary>
        /// 百灵鸟引擎
        /// </summary>
        public LarkEngineController(
            ILarkEngineCore larkEngineCore
            )
        {
            _larkEngineCore = larkEngineCore;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("Run")]
        public async Task<string> Run(LarkEngineRunInput input)
        {
            return await _larkEngineCore.Run(input);
        }
    }
}
