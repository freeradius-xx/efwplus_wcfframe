using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EFWCoreLib.WcfFrame.WcfService.Contract;
using EFWCoreLib.CoreFrame.Init;
using System.Net;
using System.Text.RegularExpressions;
using EFWCoreLib.CoreFrame.Common;

namespace EFWCoreLib.WcfFrame.ClientController
{
    /// <summary>
    /// WCF通讯客户端管理
    /// </summary>
    public class WcfClientManage
    {
        public static bool IsHeartbeat = false;
        public static int HeartbeatTime = 1;//默认间隔1秒,客户端5倍
        public static bool IsMessage = false;
        public static int MessageTime = 1;//默认间隔1秒
        public static bool IsCompressJson = false;//是否压缩Json数据
        public static bool IsEncryptionJson = false;//是否加密Json数据
        public static readonly string myNamespace = "http://www.efwplus.cn/";

        private static bool ServerConfigRequestState = false;//获取服务端配置读取状态
        private static DuplexChannelFactory<IWCFHandlerService> mChannelFactory;
        /// <summary>
        /// 创建wcf服务连接
        /// </summary>
        /// <param name="mainfrm"></param>
        public static IWCFHandlerService CreateConnection(IClientService client)
        {
            try
            {
                //NetTcpBinding binding = new NetTcpBinding("NetTcpBinding_WCFHandlerService");
                mChannelFactory = new DuplexChannelFactory<IWCFHandlerService>(client, "myendpoint");
                IWCFHandlerService wcfHandlerService = mChannelFactory.CreateChannel();
                
                string routerID;
                string mProxyID;
                using (var scope = new OperationContextScope(wcfHandlerService as IContextChannel))
                {
                    // 注意namespace必须和ServiceContract中定义的namespace保持一致，默认是：http://tempuri.org   
                    routerID = Guid.NewGuid().ToString();
                    var router = System.ServiceModel.Channels.MessageHeader.CreateHeader("routerID", myNamespace, routerID);
                    OperationContext.Current.OutgoingMessageHeaders.Add(router);
                    mProxyID = wcfHandlerService.CreateDomain(getLocalIPAddress());

                    if (WcfClientManage.ServerConfigRequestState == false)
                    {
                        //重新获取服务端配置，如：是否压缩Json、是否加密Json
                        string serverConfig = wcfHandlerService.ServerConfig();
                        WcfClientManage.IsHeartbeat = serverConfig.Split(new char[] { '#' })[0] == "1" ? true : false;
                        WcfClientManage.HeartbeatTime = Convert.ToInt32(serverConfig.Split(new char[] { '#' })[1]);
                        WcfClientManage.IsMessage = serverConfig.Split(new char[] { '#' })[2] == "1" ? true : false;
                        WcfClientManage.MessageTime = Convert.ToInt32(serverConfig.Split(new char[] { '#' })[3]);
                        WcfClientManage.IsCompressJson = serverConfig.Split(new char[] { '#' })[4] == "1" ? true : false;
                        WcfClientManage.IsEncryptionJson = serverConfig.Split(new char[] { '#' })[5] == "1" ? true : false;

                        if (WcfClientManage.IsHeartbeat)
                        {
                            //开启发送心跳
                            if (timer == null)
                                StartTimer();
                            else
                                timer.Start();
                        }
                        else
                        {
                            if (timer != null)
                                timer.Stop();
                        }

                        WcfClientManage.ServerConfigRequestState = true;
                    }
                }


                if (AppGlobal.cache.Contains("WCFClientID")) AppGlobal.cache.Remove("WCFClientID");
                if (AppGlobal.cache.Contains("WCFService")) AppGlobal.cache.Remove("WCFService");
                if (AppGlobal.cache.Contains("ClientService")) AppGlobal.cache.Remove("ClientService");
                if (AppGlobal.cache.Contains("routerID")) AppGlobal.cache.Remove("routerID");

                AppGlobal.cache.Add("routerID", routerID);
                AppGlobal.cache.Add("WCFClientID", mProxyID);
                AppGlobal.cache.Add("WCFService", wcfHandlerService);
                AppGlobal.cache.Add("ClientService", client);

                return wcfHandlerService;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        /// <summary>
        /// 重新连接wcf服务，服务端存在ClientID
        /// </summary>
        /// <param name="mainfrm"></param>
        public static void ReConnection(bool isRequest)
        {
            try
            {
                IWCFHandlerService wcfHandlerService = mChannelFactory.CreateChannel();

                if (AppGlobal.cache.Contains("WCFService")) AppGlobal.cache.Remove("WCFService");
                AppGlobal.cache.Add("WCFService", wcfHandlerService);

                if (isRequest==true)//避免死循环
                    Heartbeat();//重连之后必须再次调用心跳
            }
            catch
            {
                //throw new Exception(err.Message);
            }
        }
        /// <summary>
        /// 发送心跳
        /// </summary>
        /// <returns></returns>
        public static bool Heartbeat()
        {
            try
            {
                bool ret = false;
                IWCFHandlerService _wcfService = AppGlobal.cache.GetData("WCFService") as IWCFHandlerService;
                using (var scope = new OperationContextScope(_wcfService as IContextChannel))
                {
                    var router = System.ServiceModel.Channels.MessageHeader.CreateHeader("routerID", myNamespace, AppGlobal.cache.GetData("routerID").ToString());
                    OperationContext.Current.OutgoingMessageHeaders.Add(router);
                    ret = _wcfService.Heartbeat(AppGlobal.cache.GetData("WCFClientID").ToString());

                    if (WcfClientManage.ServerConfigRequestState == false)
                    {
                        //重新获取服务端配置，如：是否压缩Json、是否加密Json
                        string serverConfig = _wcfService.ServerConfig();
                        WcfClientManage.IsHeartbeat = serverConfig.Split(new char[] { '#' })[0] == "1" ? true : false;
                        WcfClientManage.HeartbeatTime = Convert.ToInt32(serverConfig.Split(new char[] { '#' })[1]);
                        WcfClientManage.IsMessage = serverConfig.Split(new char[] { '#' })[2] == "1" ? true : false;
                        WcfClientManage.MessageTime = Convert.ToInt32(serverConfig.Split(new char[] { '#' })[3]);
                        WcfClientManage.IsCompressJson = serverConfig.Split(new char[] { '#' })[4] == "1" ? true : false;
                        WcfClientManage.IsEncryptionJson = serverConfig.Split(new char[] { '#' })[5] == "1" ? true : false;

                        if (WcfClientManage.IsHeartbeat)
                        {
                            //开启发送心跳
                            if (timer == null)
                                StartTimer();
                            else
                                timer.Start();
                        }
                        else
                        {
                            if (timer != null)
                                timer.Stop();
                        }
                        WcfClientManage.ServerConfigRequestState = true;
                    }
                }

                if (ret == false)//表示服务主机关闭过，丢失了clientId，必须重新创建连接
                {
                    mChannelFactory.Abort();//关闭原来通道
                    CreateConnection(AppGlobal.cache.GetData("ClientService") as IClientService);
                }
                return ret;
            }
            catch
            {
                WcfClientManage.ServerConfigRequestState = false;
                ReConnection(false);//连接服务主机失败，重连
                return false;
            }
        }

        /// <summary>
        /// 向服务发送请求
        /// </summary>
        /// <param name="controller">控制器名称</param>
        /// <param name="method">方法名称</param>
        /// <param name="jsondata">数据</param>
        /// <returns>返回Json数据</returns>
        public static string Request(string controller, string method, string jsondata)
        {
            try
            {
                if (WcfClientManage.IsCompressJson)//开启压缩
                {
                    jsondata = ZipComporessor.Compress(jsondata);//压缩传入参数
                }

                IWCFHandlerService _wcfService = AppGlobal.cache.GetData("WCFService") as IWCFHandlerService;
                string retJson;
                using (var scope = new OperationContextScope(_wcfService as IContextChannel))
                {
                    var router = System.ServiceModel.Channels.MessageHeader.CreateHeader("routerID", myNamespace, AppGlobal.cache.GetData("routerID").ToString());
                    OperationContext.Current.OutgoingMessageHeaders.Add(router);
                    retJson = _wcfService.ProcessRequest(AppGlobal.cache.GetData("WCFClientID").ToString(), controller, method, jsondata);
                }

                if (WcfClientManage.IsCompressJson)
                {
                    retJson = ZipComporessor.Decompress(retJson);
                }

                if (WcfClientManage.IsHeartbeat == false)//如果没有启动心跳，则请求发送心跳
                {
                    WcfClientManage.ServerConfigRequestState = false;
                    Heartbeat();
                }

                return retJson;
            }
            catch (Exception e)
            {
                WcfClientManage.ServerConfigRequestState = false;
                ReConnection(true);//连接服务主机失败，重连
                throw new Exception(e.Message + "\n连接服务主机失败，请联系管理员！");
            }
        }

        /// <summary>
        /// 向服务发送异步请求
        /// 客户端建议不要用多线程，都采用异步请求方式
        /// </summary>
        /// <param name="controller">控制器名称</param>
        /// <param name="method">方法名称</param>
        /// <param name="jsondata">数据</param>
        /// <returns>返回Json数据</returns>
        public static IAsyncResult RequestAsync(string controller, string method, string jsondata, Action<string> action)
        {
            try
            {
                if (WcfClientManage.IsCompressJson)//开启压缩
                {
                    jsondata = ZipComporessor.Compress(jsondata);//压缩传入参数
                }

                IWCFHandlerService _wcfService = AppGlobal.cache.GetData("WCFService") as IWCFHandlerService;
                //string retJson;
                IAsyncResult result = null;
                using (var scope = new OperationContextScope(_wcfService as IContextChannel))
                {
                    var router = System.ServiceModel.Channels.MessageHeader.CreateHeader("routerID", myNamespace, AppGlobal.cache.GetData("routerID").ToString());
                    OperationContext.Current.OutgoingMessageHeaders.Add(router);

                    AsyncCallback callback = delegate(IAsyncResult r)
                    {
                        string retJson = _wcfService.EndProcessRequest(r);

                        if (WcfClientManage.IsCompressJson)
                        {
                            retJson = ZipComporessor.Decompress(retJson);
                        }

                        action(retJson);
                    };
                    result = _wcfService.BeginProcessRequest(AppGlobal.cache.GetData("WCFClientID").ToString(), controller, method, jsondata, callback, null);
                }

                if (WcfClientManage.IsHeartbeat == false)//如果没有启动心跳，则请求发送心跳
                {
                    WcfClientManage.ServerConfigRequestState = false;
                    Heartbeat();
                }

                //return retJson;
                return result;
            }
            catch (Exception e)
            {
                WcfClientManage.ServerConfigRequestState = false;
                ReConnection(true);//连接服务主机失败，重连
                throw new Exception(e.Message + "\n连接服务主机失败，请联系管理员！");
            }
        }


        /// <summary>
        /// 卸载连接
        /// </summary>
        public static void UnConnection()
        {
            if (AppGlobal.cache.GetData("WCFClientID") == null) return;

            //bool b = false;
            string mClientID = AppGlobal.cache.GetData("WCFClientID").ToString();
            IWCFHandlerService mWcfService = AppGlobal.cache.GetData("WCFService") as IWCFHandlerService;
            if (mClientID != null)
            {
                using (var scope = new OperationContextScope(mWcfService as IContextChannel))
                {
                    try
                    {
                        var router = System.ServiceModel.Channels.MessageHeader.CreateHeader("routerID", "http://www.efwplus.cn/", AppGlobal.cache.GetData("routerID").ToString());
                        OperationContext.Current.OutgoingMessageHeaders.Add(router);
                        var cmd = System.ServiceModel.Channels.MessageHeader.CreateHeader("CMD", "http://www.efwplus.cn/", "Quit");
                        OperationContext.Current.OutgoingMessageHeaders.Add(cmd);
                        mWcfService.UnDomain(mClientID);

                        mChannelFactory.Close();//关闭通道

                        if (timer != null)//关闭连接必须停止心跳
                            timer.Stop();
                    }
                    catch
                    {
                        if (mChannelFactory != null)
                            mChannelFactory.Abort();
                    }
                }
            }
        }
        /// <summary>
        /// 广播消息接收(暂无用)
        /// </summary>
        /// <param name="jsondata"></param>
        public static void ReplyClient(string jsondata)
        {

        }

        //向服务端发送心跳，间隔时间为5s
        static System.Timers.Timer timer;
        static void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = WcfClientManage.HeartbeatTime*5*1000;//客户端比服务端心跳间隔多5倍
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        static Object syncObj = new Object();////定义一个静态对象用于线程部份代码块的锁定，用于lock操作
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (syncObj)
            {
                try
                {
                    Heartbeat();
                }
                catch
                {
                    //throw new Exception(err.Message);
                }
            }
        }
        static string getLocalIPAddress()
        {
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            string myip = "";
            foreach (IPAddress ip in IpEntry.AddressList)
            {
                if (Regex.IsMatch(ip.ToString(), @"\d{0,3}\.\d{0,3}\.\d{0,3}\.\d{0,3}"))
                {
                    myip = ip.ToString();
                    break;
                }
            }
            return myip;
        }
    }
}
