using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Helpers
{
    /// <summary>
    /// 字符串助手类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 转化为小写数据库专用名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLowerDatabaseName(this string? str)
        {
            if (str is null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(str[0].ToString().ToLower());
            for (int i = 1; i < str.Length; i++)
            {
                char chr = str[i];
                if (chr >= 'A' && chr <= 'Z')
                {
                    sb.Append('_');
                    sb.Append(str[0].ToString().ToLower());
                }
                else
                {
                    sb.Append(chr);
                }
            }
            return sb.ToString();
        }
    }
}
