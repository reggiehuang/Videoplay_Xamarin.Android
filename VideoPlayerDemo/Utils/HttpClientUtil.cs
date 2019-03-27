using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util.Concurrent;
using Newtonsoft.Json;
using Square.OkHttp3;

namespace VideoPlayerDemo.Utils
{
    public class OkHttpClientUtil
    {
        private OkHttpClient httpClient;
        public OkHttpClientUtil()
        {
            httpClient = new OkHttpClient.Builder()
           .ConnectTimeout(5, TimeUnit.Seconds)//连接超时5秒
           .WriteTimeout(5, TimeUnit.Seconds)//写入数据超时5秒
           .ReadTimeout(5, TimeUnit.Seconds)//读取数据超时5秒
           .Build();
        }
        public static OkHttpClientUtil Instance()
        {
            return new OkHttpClientUtil();
        }

        public async System.Threading.Tasks.Task<bool> Post(string url, Object user)
        {
            FormBody.Builder formBody = new FormBody.Builder(); //创建表单请求体
            formBody.Add("name", "1");
            formBody.Add("pwd", "2");
            Request request = new Request.Builder().AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8").Url(url).Post(formBody.Build()).Build();
            var response = await httpClient.NewCall(request).ExecuteAsync();
            if (response.Code() == 200)
            {
                var result = JsonConvert.DeserializeObject<string>(response.Body().String());
                if (result == "success")
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async System.Threading.Tasks.Task<byte[]> Get(string url)
        {
            Request request = new Request.Builder().Url(url).Build();
            Response response = await httpClient.NewCall(request).ExecuteAsync();
            if (response.Code() == 200)
            {
                var stream = response.Body().ByteStream();
                var bytes = StreamToBytes(stream);
                return bytes;
            }
            return null;
        }

        /// <summary>
        /// 1、将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }

}