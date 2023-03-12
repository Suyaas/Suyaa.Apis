using Egg.EFCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Suyaa.Apis.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egg.Data.Entities;
using Egg;

namespace Suyaa.Apis.Base.Entities.Users
{
    /// <summary>
    /// 用户信息助手
    /// </summary>
    public static class UserInfoHelper
    {
        /// <summary>
        /// 填充密码
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="password"></param>
        public static void FillPassword(this UserInfo userInfo, string password)
        {
            userInfo.Password = userInfo.CreatePasswordString(password);
        }

        /// <summary>
        /// 创建密码字符串
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="password"></param>
        public static string CreatePasswordString(this UserInfo userInfo, string password)
        {
            return $"user_no={userInfo.UserNo};password={password};".GetMD5();
        }
    }
}
