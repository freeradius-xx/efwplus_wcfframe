using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ServerController;
using Books_Wcf.Entity;
using System.Data;

namespace Books_Wcf.WcfController
{
    [WCFController]
    public class bookWcfController : JsonWcfServerController
    {
        [WCFMethod]
        public string SaveBook()
        {
            Books book = ToObject<Books>(ParamJsonData);
            book.BindDb(oleDb, _container,_cache,_pluginName);//反序列化的对象，必须绑定数据库操作对象
            book.save();
            return "true";
        }

        //[WCFMethod]
        //public string GetBooks()
        //{
        //    DataTable dt = NewObject<Books>().gettable();
        //    return base.ToJson(dt);
        //}

        [WCFMethod]
        public string GetBooks()
        {
            DataTable dt = NewObject<Books>().gettable();

            //测试数据网络传输
            if (ToArray(ParamJsonData).Length > 0)
            {
                DataTable _dt = dt.Clone();
                int num = Convert.ToInt32(ToArray(ParamJsonData)[0]);
                for (int i = 0; i < num; i++)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _dt.Rows.Add(dr.ItemArray);
                    }
                }
                //System.Threading.Thread.Sleep(40000);//测试并发问题，是序列化才是的并发的问题
                return base.ToJson(_dt);
            }
            return base.ToJson(dt);
        }
    }
}

