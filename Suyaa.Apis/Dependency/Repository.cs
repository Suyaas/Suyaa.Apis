using Suyaa.Data;
using Suyaa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Dependency
{
    /// <summary>
    /// 数据仓库
    /// </summary>
    public class Repository<TClass, Tid> : Suyaa.Data.Repository<TClass, Tid>
        where TClass : class, IEntity<Tid>
        where Tid : notnull
    {
        // 连接集合
        private readonly IConnections _connections;

        /// <summary>
        /// 数据仓库
        /// </summary>
        /// <param name="connections"></param>
        public Repository(IConnections connections) : base(connections.FindConnection<TClass>())
        {
            _connections = connections;
        }
    }
}
