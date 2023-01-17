using Egg.EFCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Entities
{
    /// <summary>
    /// 整齐化数据实例
    /// </summary>
    public abstract class NeatEntity : GuidKeyEntity
    {
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Column("creator_user_id", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Description("创建用户Id")]
        public virtual string CreatorUserId { get; set; } = "";

        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Column("creation_time", TypeName = "timestamp without time zone")]
        [Description("创建时间")]
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后更新用户Id
        /// </summary>
        [Column("last_modifier_user_id", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Description("最后更新用户Id")]
        public virtual string LastModifierUserId { get; set; } = "";

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column("last_modification_time", TypeName = "timestamp without time zone")]
        [Description("最后更新时间")]
        public virtual DateTime LastModificationTime { get; set; }

        /// <summary>
        /// 删除用户Id
        /// </summary>
        [Column("deleter_user_id", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Description("删除用户Id")]
        public virtual string? DeleterUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("deletion_time", TypeName = "timestamp without time zone")]
        [Description("删除时间")]
        public virtual DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted", TypeName = "bool")]
        [Description("是否删除")]
        public virtual bool IsDeleted { get; set; } = false;
    }
}
