using Egg;
using Microsoft.AspNetCore.Mvc;
using Suyaa.Apis.Common.Apps.Assemblies.Dtos;
using Suyaa.Microservice.Dependency;
using Suyaa.Microservice.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Suyaa.Apis.Common.Apps.Assemblies
{
    /// <summary>
    /// 程序集
    /// </summary>
    [App("Common/Assembly")]
    public class AssemblyApp : ServiceApp
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [Get]
        public List<AssemblyOutput> GetList()
        {
            List<AssemblyOutput> outputs = new List<AssemblyOutput>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var info = FileVersionInfo.GetVersionInfo(assembly.Location);
                    if (info.ProductName.IsNullOrWhiteSpace()) continue;
                    if (info.ProductName?.StartsWith("Microsoft") ?? false) continue;
                    outputs.Add(new AssemblyOutput()
                    {
                        Name = info.ProductName ?? "",
                        Version = info.ProductVersion ?? "",
                    });
                }
                catch { }
            }
            return outputs.OrderBy(d => d.Name).ToList();
        }
    }
}
