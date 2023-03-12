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

namespace Suyaa.Apis.Base.Entities.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("user_info", Schema = "base")]
    [Description("用户信息")]
    public class UserInfo : NeatEntity
    {
        /// <summary>
        /// 用户编号 - 唯一索引
        /// </summary>
        [Column("user_no")]
        [Description("用户编码")]
        [Index(Unique = true)]
        public virtual int UserNo { get; set; } = 0;
        /// <summary>
        /// 用户账号 - 索引
        /// </summary>
        [Column("user_account", TypeName = "varchar(100)")]
        [StringLength(100)]
        [Description("账号")]
        [Index]
        public virtual string? UserAccount { get; set; }
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
