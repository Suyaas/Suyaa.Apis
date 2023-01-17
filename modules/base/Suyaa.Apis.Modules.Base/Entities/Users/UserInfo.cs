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

namespace Suyaa.Apis.Modules.Base.Entities.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("user_info", Schema = "base")]
    [Description("用户信息")]
    public class UserInfo : NeatEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Column("account", TypeName = "varchar(100)")]
        [StringLength(100)]
        [Description("账号")]
        public virtual string? Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password", TypeName = "varchar(100)")]
        [StringLength(100)]
        [Description("密码")]
        public virtual string? Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nick", TypeName = "varchar(100)")]
        [StringLength(100)]
        [Description("昵称")]
        public virtual string? Nick { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Column("is_enabled", TypeName = "bool")]
        [Description("是否可用")]
        public virtual bool IsEnabled { get; set; } = false;
    }
}
