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
        public static void FillCreationInfo(this ICreationEntity entity, long userId)
        {
            entity.CreationTime = DateTime.Now;
            entity.CreatorUserId = userId;
        }

        /// <summary>
        /// 填充创建信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userNo"></param>
        public static void FillModificationInfo(this IModificationEntity entity, long userId)
        {
            entity.LastModificationTime = DateTime.Now;
            entity.LastModifierUserId = userId;
        }

        /// <summary>
        /// 填充创建信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userNo"></param>
        public static void FillDeletionInfo(this IDeletionEntity entity, long userId)
        {
            entity.DeletionTime = DateTime.Now;
            entity.DeleterUserId = userId;
            entity.IsDeleted = true;
        }
    }
}
