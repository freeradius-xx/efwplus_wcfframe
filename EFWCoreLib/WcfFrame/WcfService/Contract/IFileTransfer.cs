using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EFWCoreLib.WcfFrame.WcfService.Contract
{
    /// <summary>
    /// 文件传输服务
    /// </summary>
    [ServiceKnownType(typeof(DBNull))]
    [ServiceContract(Namespace = "http://www.efwplus.cn/", Name = "FileTransferHandlerService", SessionMode = SessionMode.Required)]
    public interface IFileTransfer
    {
        [OperationContract]
        result UpLoadFile(FileWrapper fileWrapper);

        [OperationContract]
        Stream DownLoadFile(string downfilepath);
    }

    /// <summary>
    /// 消息契约（定义与SOAP消息相对应的强类型）
    /// 因为我们用流传输，所以用消息契约代替传统的数据契约
    /// 
    /// </summary>
    [MessageContract]
    public class FileWrapper
    {
        /// <summary>
        ///SOAP的消息头这里即为标记文件的路径
        /// </summary>
        [MessageHeader]
        public string FilePath;
        /// <summary>
        /// SOAP消息的内容，指定成员序列化正文中的元素
        /// </summary>
        [MessageBodyMember]
        public Stream FileData;
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    [MessageContract]
    public class result
    {
        [MessageBodyMember]
        public bool returnresult;

        [MessageBodyMember]
        public bool returnfilepath;
    }
}
