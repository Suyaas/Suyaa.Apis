using Suyaa.Data.Entities;
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
    /// 用户登录信息
    /// </summary>
    [Table("user_login_info")]
    public class UserLoginInfo : NeatEntity
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [Description("用户编号")]
        [Column("user_no", TypeName = "bigint")]
        public virtual long UserNo { get; set; } = 0;

        /// <summary>
        /// 登录IP
        /// </summary>
        [Description("登录IP")]
        [Column("login_ip", TypeName = "varchar(128)")]
        [StringLength(128)]
        public virtual string LoginIp { get; set; } = string.Empty;

        /// <summary>
        /// 是否退出登录
        /// </summary>
        [Description("是否退出登录")]
        [Column("is_logout", TypeName = "bool")]
        public virtual bool IsLogout { get; set; } = false;
    }
}
