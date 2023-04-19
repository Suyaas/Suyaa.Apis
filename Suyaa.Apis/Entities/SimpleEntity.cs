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
    /// 简单数据实例
    /// </summary>
    public abstract class SimpleEntity : GuidKeyEntity, ICreationEntity
    {
        /// <summary>
        /// 创建用户编号
        /// </summary>
        [Column("creator_user_no")]
        [Description("创建用户Id")]
        public virtual long CreatorUserId { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("creation_time", TypeName = "timestamp without time zone")]
        [Description("创建时间")]
        public virtual DateTime CreationTime { get; set; }
    }
}
