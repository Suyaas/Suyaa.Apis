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
    /// 带修改信息的数据实例
    /// </summary>
    public interface IModificationEntity
    {
        /// <summary>
        /// 最后修改用户编号
        /// </summary>
        int LastModifierUserNo { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime LastModificationTime { get; set; }
    }
}
