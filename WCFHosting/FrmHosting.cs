﻿using System;
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
        long timeCount = 0;//运行次数
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

                    lbStatus.Text = "服务未启动";
                    timer1.Enabled = false;
                }
                else
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    启动ToolStripMenuItem.Enabled = false;
                    停止ToolStripMenuItem.Enabled = true;

                    lbStatus.Text = "服务已运行";
                    timeCount = 0;
                    timer1.Enabled = true;
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

            AddMsg(Color.Blue,DateTime.Now, "WCF主机启动完成");
           
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

            AddMsg(Color.Blue,DateTime.Now, "路由器启动完成");
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
                        AddMsg(Color.Blue, DateTime.Now, "WCF主机已关闭");
                    }

                    if (mRouterHost != null)
                    {
                        mRouterHost.Close();
                        RouterHandlerService.Dispose();
                        AddMsg(Color.Blue, DateTime.Now, "路由器已关闭");
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
            lsServerUrl.Text = ReadConfig.GetWcfServerUrl();
            btnStart_Click(null, null);//打开服务主机后自动启动服务
        }

        public delegate void textInvoke(Color clr, string msg);
        public delegate void gridInvoke(DataGridView grid, object data);
        private void settext(Color clr, string msg)
        {
            if (richTextMsg.InvokeRequired)
            {
                textInvoke ti = new textInvoke(settext);
                this.BeginInvoke(ti, new object[] { clr, msg });
            }
            else
            {
                ListViewItem lstItem = new ListViewItem(msg);
                lstItem.ForeColor = clr;
                if (richTextMsg.Items.Count > 1000)
                    richTextMsg.Items.Clear();
                richTextMsg.Items.Add(lstItem);
                richTextMsg.SelectedIndex = richTextMsg.Items.Count - 1;
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
        private void AddMsg(Color clr, DateTime time, string msg)
        {
            msg = msg.Length > 10000 ? msg.Substring(0, 10000) : msg;
            settext(clr,"[" + time.ToString("yyyy-MM-dd HH:mm:ss") + "] : " + msg);
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

        private void 清除日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextMsg.Items.Clear();
        }

        private void 复制日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextMsg.SelectedItem == null)
                return;
            StringBuilder strMessage = new StringBuilder();
            for (int i = 0; i < richTextMsg.Items.Count; i++)
            {
                if (richTextMsg.GetSelected(i))
                    strMessage.Append(richTextMsg.SelectedItem.ToString());
            }

            Clipboard.SetDataObject(strMessage.ToString());
        }

        private void richTextMsg_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            ListViewItem lstItem = (ListViewItem)richTextMsg.Items[e.Index];
            e.DrawBackground();
            Brush brsh = Brushes.White;
            if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
                brsh = new SolidBrush(lstItem.ForeColor);
            String sText = lstItem.Text.Replace('\n', ' ');
            SizeF sz = e.Graphics.MeasureString(sText, e.Font, new SizeF(e.Bounds.Width, e.Bounds.Height));
            e.Graphics.DrawString(sText, e.Font, brsh, e.Bounds.Left, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 0.5f);
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 2)
                lsServerUrl.Text = ReadConfig.GetRouterUrl();
            else
                lsServerUrl.Text = ReadConfig.GetWcfServerUrl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCount++;
            //显示运行时间
            long iHour = timeCount / 3600;
            long iMin = (timeCount % 3600) / 60;
            long iSec = timeCount % 60;
            if (iHour > 23)
                lbRunTime.Text = String.Format("{0}天 {1:02d}:{2:0#}:{3:0#}", iHour / 24, iHour % 24, iMin, iSec);
            else
                lbRunTime.Text = String.Format("{0:0#}:{1:0#}:{2:0#}", iHour, iMin, iSec);
        }
    }

    public enum HostState
    {
        NoOpen,Opened
    }
}
