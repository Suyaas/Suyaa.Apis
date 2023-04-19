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
    /// 带创建信息的数据实例
    /// </summary>
    public interface ICreationEntity
    {
        /// <summary>
        /// 创建用户编号
        /// </summary>
        long CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
