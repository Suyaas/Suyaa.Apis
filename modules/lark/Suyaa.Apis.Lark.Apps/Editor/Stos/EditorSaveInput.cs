using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Lark.Apps.Editor.Stos
{
    /// <summary>
    /// 保存入参
    /// </summary>
    public class EditorSaveInput
    {
        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path { get; set; } = string.Empty;

        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; } = string.Empty;
    }
}
