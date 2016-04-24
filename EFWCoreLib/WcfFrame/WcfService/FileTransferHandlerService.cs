using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WcfFrame.WcfService.Contract;

namespace EFWCoreLib.WcfFrame.WcfService
{
    //InstanceContextMode.PerCall 文件传输调用次数少，用这种方式即可
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single, UseSynchronizationContext = false, IncludeExceptionDetailInFaults = true)]
    public class FileTransferHandlerService : IFileTransfer
    {

        #region IFileTransfer 成员

        public result UpLoadFile(FileWrapper fileWrapper)
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream DownLoadFile(string downfilepath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
