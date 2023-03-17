using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Entities
{
    /// <summary>
    /// 创建实例助手
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// 填充创建信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userNo"></param>
        public static void FillCreationInfo(this ICreationEntity entity, int userNo)
        {
            entity.CreationTime = DateTime.Now;
            entity.CreatorUserNo = userNo;
        }

        /// <summary>
        /// 填充创建信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userNo"></param>
        public static void FillModificationInfo(this IModificationEntity entity, int userNo)
        {
            entity.LastModificationTime = DateTime.Now;
            entity.LastModifierUserNo = userNo;
        }

        /// <summary>
        /// 填充创建信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userNo"></param>
        public static void FillDeletionInfo(this IDeletionEntity entity, int userNo)
        {
            entity.DeletionTime = DateTime.Now;
            entity.DeleterUserNo = userNo;
            entity.IsDeleted = true;
        }
    }
}
