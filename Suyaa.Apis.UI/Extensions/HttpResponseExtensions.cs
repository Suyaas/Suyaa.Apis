using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Suyaa.Apis.UI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.UI.Extensions
{
    /// <summary>
    /// 应用程序构建帮助
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// 呈现文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task RenderFileAsync(this HttpResponse response, string path, string contentType)
        {
            response.Clear();
            response.StatusCode = 200;
            response.ContentType = contentType;
            byte[] buffer = new byte[4096];
            using (var f = sy.IO.OpenFile(path))
            {
                response.ContentLength = f.Length;
                int len = 0;
                do
                {
                    len = f.Read(buffer, 0, buffer.Length);
                    if (len > 0) await response.Body.WriteAsync(buffer, 0, len);
                } while (len > 0);
            }
            await response.Body.FlushAsync();
        }

        /// <summary>
        /// 呈现404
        /// </summary>
        /// <returns></returns>
        public static async Task Render404Async(this HttpResponse response)
        {
            response.Clear();
            response.StatusCode = 404;
            response.ContentType = "text/plain";
            await response.Body.WriteAsync(Encoding.UTF8.GetBytes("Not found 404"));
        }
    }
}
