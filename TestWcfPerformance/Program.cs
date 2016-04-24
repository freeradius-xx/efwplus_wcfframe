using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Init;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.WcfService.Contract;

namespace TestWcfPerformance
{
    //测试WCF在互联网下请求数据的性能
    class Program
    {
        static void Main(string[] args)
        {
            begintime();
            //1.初始化
            AppGlobal.AppStart();
            Console.WriteLine("1.初始化程序时间(毫秒)：" + endtime());

            begintime();
            //2.创建连接
            ReplyClientCallBack callback = new ReplyClientCallBack();
            WcfClientManage.CreateConnection(callback);
            Console.WriteLine("2.创建连接时间(毫秒)：" + endtime());

            Console.WriteLine("输入请求数据条数：");
            string num= Console.ReadLine();
            begintime();
            //3.同步请求数据
            string retjson = WcfClientManage.Request("Books_Wcf@bookWcfController", "GetBooks", "[" + num + "]");
            Console.WriteLine("3.请求数据时间(毫秒)：" + endtime());
            //3.异步请求数据
            //WcfClientManage.RequestAsync("Books_Wcf@bookWcfController", "GetBooks", "[" + num + "]", new Action<string>(
            //    (json) =>
            //    {
            //        Console.WriteLine("3.请求数据时间(毫秒)：" + endtime());
            //    }
            //    ));
            

            begintime();
            //4.回调消息
            callback.ReplyClientAction = new Action<string>((json) =>
            {

            });
            Console.WriteLine("4.回调消息时间(毫秒)：" + endtime());

            begintime();
            //5.关闭连接
            //WcfClientManage.UnConnection();
            //Console.WriteLine("5.关闭连接时间(毫秒)：" + endtime());
            Console.Read();
        }


        static DateTime begindate;
        static void begintime()
        {
            begindate = DateTime.Now;
        }
        //返回毫秒
        static double endtime()
        {
            return DateTime.Now.Subtract(begindate).TotalMilliseconds;
        }
    }
}
