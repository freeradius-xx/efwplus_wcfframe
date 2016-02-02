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
        [WCFMethod]
        public string GetBooks()
        {
            DataTable dt = NewObject<Books>().gettable();
            return base.ToJson(dt);
        }
    }
}

