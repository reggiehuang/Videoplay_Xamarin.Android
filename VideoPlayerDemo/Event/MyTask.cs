using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Net;
using Square.OkHttp3;

namespace VideoPlayerDemo.Event
{
    public class MyTask : AsyncTask<string, int, string>
    {
        public interface IMyTask
        {
            void OnFinish(string result);//定义一个回调方法
        }

        private IMyTask _myTask;
        public void SetLitener(IMyTask listener)//传递一个实现了IMyTask接口的对象来监听任务结果
        {
            _myTask = listener;
        }

        //在异步任务开始之前被调用(在主线程)
        protected override void OnPreExecute()
        {
            Log.Debug("MyTask", "在异步任务开始之前OnPreExecute()被调用");
        }

        //(在子线程运行具体任务)
        //此方法内部会创建子线程Thread，然后执行任务，然后会发送Message到消息队列。
        protected override string RunInBackground(params string[] @params)////因为params和C#关键字params同名，所以要加 @ 符号
        {
            Log.Debug("MyTask", "RunInBackground()被调用");
            HttpURLConnection conn = null;
            try
            {
                string result;
                string address = @params[0];//取出请求地址
                //OkHttpClient client = new OkHttpClient();


                //// Create request for remote resource.
                //Request request = new Request.Builder()
                //    .Url(address)
                //    .Build();

                //// Execute the request and retrieve the response.
                //Response response = client.NewCall(request).ExecuteAsync().Result;

                //// Deserialize HTTP response to concrete type.
                //string body = response.Body().StringAsync().Result;
                //result = body;


                URL url = new URL(address);
                conn = (HttpURLConnection)url.OpenConnection(); //打开连接
                conn.RequestMethod = "GET";
                conn.DoInput = true;  //允许接收数据，以后就可以使用conn.InputStream

                Stream inStream = conn.InputStream; //实际请求数据
              
                using (StreamReader reader = new StreamReader(inStream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch
            {
                return "";
            }
            finally
            {
                if (conn != null) conn.Disconnect();//关闭连接
            }
        }

        //进度有变化时被调用(在主线程)
        //protected override void OnProgressUpdate(params int[] values)
        //{
        //    base.OnProgressUpdate(values);
        //}

        //异步任务执行完后被调用(在主线程)
        protected override void OnPostExecute(string result)
        {
            Log.Debug("MyTask", "异步任务执行完后OnPostExecute()被调用");
            if (_myTask != null)
            {
                _myTask.OnFinish(result); //执行回调方法
            }
        }
 
        //任务被取消后调用
        //protected override void OnCancelled()
        //{
        //    base.OnCancelled();
        //}
    }
}