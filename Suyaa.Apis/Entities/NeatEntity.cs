using Suyaa.EFCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.EFCore.Dbsets;
using Suyaa.Data.Entities;

namespace Suyaa.Apis.Entities
{
    /// <summary>
    /// 整齐化数据实例
    /// </summary>
    public abstract class NeatEntity : SimpleEntity, IModificationEntity, IDeletionEntity
    {
        /// <summary>
        /// 最后修改用户编号
        /// </summary>
        [Column("last_modifier_user_no")]
        [Description("最后修改用户编号")]
        public virtual long LastModifierUserNo { get; set; } = 0;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column("last_modification_time", TypeName = "timestamp without time zone")]
        [Description("最后更新时间")]
        public virtual DateTime LastModificationTime { get; set; }

        /// <summary>
        /// 删除用户编号
        /// </summary>
        [Column("deleter_user_no")]
        [StringLength(50)]
        [Description("删除用户编号")]
        public virtual long? DeleterUserNo { get; set; }

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
