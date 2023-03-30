﻿using Egg.Data.Entities;
using Suyaa.Apis.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.User.Entities.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("user_info")]
    public class UserInfo : NeatEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        [Column("account", TypeName = "varchar(128)")]
        [StringLength(128)]
        public virtual string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        [Column("password", TypeName = "varchar(128)")]
        [StringLength(128)]
        public virtual string Password { get; set; } = string.Empty;
    }
}