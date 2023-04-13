using Suyaa.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Attributes
{
    /// <summary>
    /// 数据库字段
    /// </summary>
    public class DBColumnAttribute : ColumnAttribute
    {
        public DBColumnAttribute(string name) : base(name.ToLowerDatabaseName()) { }
    }
}
