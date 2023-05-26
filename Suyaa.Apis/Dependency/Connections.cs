using Suyaa.Data;
using Suyaa.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Dependency
{
    /// <summary>
    /// 连接池
    /// </summary>
    public class Connections : IConnections
    {
        // 私有变量
        private readonly StringKeyDictionary<IDatabaseConnectionInfo> _connectionInfos;
        private readonly Dictionary<Type, string> _types;

        /// <summary>
        /// 连接池
        /// </summary>
        public Connections()
        {
            _connectionInfos = new StringKeyDictionary<IDatabaseConnectionInfo>();
            _types = new Dictionary<Type, string>();
        }

        /// <summary>
        /// 添加连接信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        /// <exception cref="FriendlyException"></exception>
        public Connections AddConnectionInfo(string key, IDatabaseConnectionInfo connectionInfo)
        {
            if (_connectionInfos.ContainsKey(key)) throw new HostFriendlyException($"存在重复的'{key}'连接信息");
            _connectionInfos.Add(key, connectionInfo);
            return this;
        }

        /// <summary>
        /// 添加连接信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        /// <exception cref="FriendlyException"></exception>
        public Connections AddTypes(string key, params Type[] types)
        {
            foreach (var type in types)
            {
                if (_types.ContainsKey(type)) throw new HostFriendlyException($"已有类型为'{type.FullName}'的配置信息");
                _types.Add(type, key);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="FriendlyException"></exception>
        public IDatabaseConnection FindConnection<T>()
        {
            var type = typeof(T);
            if (!_types.ContainsKey(type)) throw new HostFriendlyException($"未找到类型为'{type.FullName}'的配置信息");
            string key = _types[type];
            if (!_connectionInfos.ContainsKey(key)) throw new HostFriendlyException($"未找到名称为'{key}'的连接信息");
            return new DatabaseConnection(_connectionInfos[key]);
        }
    }
}
