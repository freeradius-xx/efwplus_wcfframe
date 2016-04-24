using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Init;
using System.ServiceModel;
using System.ServiceModel.Description;
using EFWCoreLib.WcfFrame.ServerController;
using EFWCoreLib.WcfFrame.WcfService;

namespace WCFHosting
{
    public partial class FrmHosting : Form
    {
        ServiceHost mAppHost = null;
        ServiceHost mRouterHost = null;
        HostState RunState
        {
            set
            {
                if (value == HostState.NoOpen)
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    启动ToolStripMenuItem.Enabled = true;
                    停止ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    启动ToolStripMenuItem.Enabled = false;
                    停止ToolStripMenuItem.Enabled = true;
                }
            }
        }

        public FrmHosting()
        {
            InitializeComponent();
        }

        private void GetSettingConfig()
        {

        }

        private void StartAppHost()
        {

           

            WcfServerManage.hostwcfclientinfoList = new HostWCFClientInfoListHandler(BindGridClient);
            WcfServerManage.hostwcfMsg = new HostWCFMsgHandler(AddMsg);

            mAppHost = new ServiceHost(typeof(WCFHandlerService));

            //ServiceMetadataBehavior smb = mAppHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            //if (smb == null)
            //{
            //    mAppHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
            //}

            //mAppHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            mAppHost.Open();
            WcfServerManage.IsDebug = HostSettingConfig.GetValue("debug") == "1" ? true : false;
            WcfServerManage.IsHeartbeat = HostSettingConfig.GetValue("heartbeat") == "1" ? true : false;
            WcfServerManage.HeartbeatTime = Convert.ToInt32(HostSettingConfig.GetValue("heartbeattime"));
            WcfServerManage.IsMessage = HostSettingConfig.GetValue("message") == "1" ? true : false;
            WcfServerManage.MessageTime = Convert.ToInt32(HostSettingConfig.GetValue("messagetime"));
            WcfServerManage.IsCompressJson = HostSettingConfig.GetValue("compress") == "1" ? true : false;
            WcfServerManage.IsEncryptionJson = HostSettingConfig.GetValue("encryption") == "1" ? true : false;
            WcfServerManage.IsOverTime = HostSettingConfig.GetValue("overtime") == "1" ? true : false;
            WcfServerManage.OverTime = Convert.ToInt32(HostSettingConfig.GetValue("overtimetime"));
            WcfServerManage.StartWCFHost();

            AddMsg(DateTime.Now, "WCF主机启动完成");
           
        }
        private void StartRouterHost()
        {
            RouterHandlerService.hostwcfMsg = new HostWCFMsgHandler(AddMsg);
            RouterHandlerService.hostwcfRouter = new HostWCFRouterListHandler(BindGridRouter);

            mRouterHost = new ServiceHost(typeof(RouterHandlerService));

            //ServiceMetadataBehavior smb = mRouterHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            //if (smb == null)
            //{
            //    mRouterHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
            //}
            //mRouterHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            mRouterHost.Open();

            AddMsg(DateTime.Now, "路由器启动完成");
            //Loader.hostwcfclientinfoList = new HostWCFClientInfoListHandler(BindGridClient);
           
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(HostSettingConfig.GetValue("wcfservice")) == 1)
                StartAppHost();
            if (Convert.ToInt32(HostSettingConfig.GetValue("router")) == 1)
                StartRouterHost();
            RunState = HostState.Opened;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要停止服务吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    if (mAppHost != null)
                    {
                        WcfServerManage.StopWCFHost();
                        mAppHost.Close();
                        AddMsg(DateTime.Now, "WCF主机已关闭");
                    }

                    if (mRouterHost != null)
                    {
                        mRouterHost.Close();
                        RouterHandlerService.Dispose();
                        AddMsg(DateTime.Now, "路由器已关闭");
                    }
                }
                catch
                {
                    if (mAppHost != null)
                        mAppHost.Abort();
                    if (mRouterHost != null)
                        mRouterHost.Abort();
                }
                RunState = HostState.NoOpen;
            }
        }

        private void FrmHosting_Load(object sender, EventArgs e)
        {
            this.Text = "WCF服务主机【" + HostSettingConfig.GetValue("hostname") + "】";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.Text = this.Text;

            RunState = HostState.NoOpen;

            btnStart_Click(null, null);//打开服务主机后自动启动服务
        }

        public delegate void textInvoke(string msg);
        public delegate void gridInvoke(DataGridView grid, object data);
        private void settext(string msg)
        {
            if (richTextMsg.InvokeRequired)
            {
                textInvoke ti = new textInvoke(settext);
                this.BeginInvoke(ti, new object[] { msg });
            }
            else
            {
                if (richTextMsg.Text.Length == 0)
                    msg = msg.Replace("\n", "");
                if (richTextMsg.Lines.Length > 1 && richTextMsg.Lines[richTextMsg.Lines.Length - 1].Length == 0)
                    msg = msg.Replace("\n", "");
                richTextMsg.AppendText(msg + "\n");
            }
        }
        private void setgrid(DataGridView grid, object data)
        {
            if (grid.InvokeRequired)
            {
                gridInvoke gi = new gridInvoke(setgrid);
                this.BeginInvoke(gi, new object[] { grid, data });
            }
            else
            {
                grid.AutoGenerateColumns = false;
                grid.DataSource = data;
                grid.Refresh();
            }
        }

        private void BindGridClient(List<WCFClientInfo> dic)
        {
            setgrid(gridClientList,dic);
        }
        private void AddMsg(DateTime time, string msg)
        {
            settext("\n[" + time.ToString("yyyy-MM-dd HH:mm:ss") + "] : " + msg);
        }
        private void BindGridRouter(List<RegistrationInfo> dic)
        {
            setgrid(gridRouter, dic);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(null, null);
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出WCF服务主机吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose(true);
            }
        }

        private void FrmHosting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSetting set = new FrmSetting();
            set.ShowDialog();
            if (set.isOk == true)
            {
                this.Text = "WCF服务主机【" + HostSettingConfig.GetValue("hostname") + "】";
                this.notifyIcon1.Text = this.Text;
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void btnplugin_Click(object sender, EventArgs e)
        {
            FrmPlugin plugin = new FrmPlugin();
            plugin.ShowDialog();
        }
    }

    public enum HostState
    {
        NoOpen,Opened
    }
}
