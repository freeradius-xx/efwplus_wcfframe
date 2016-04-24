using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCFHosting
{
    public partial class FrmSetting : Form
    {
        public bool isOk = false;
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HostSettingConfig.SetValue("hostname", txthostname.Text);
            HostSettingConfig.SetValue("debug", ckdebug.Checked ? "1" : "0");
            HostSettingConfig.SetValue("wcfservice", ckwcf.Checked ? "1" : "0");
            HostSettingConfig.SetValue("router", ckrouter.Checked ? "1" : "0");
            HostSettingConfig.SetValue("heartbeat", ckheartbeat.Checked ? "1" : "0");
            HostSettingConfig.SetValue("heartbeattime",txtheartbeattime.Text);
            HostSettingConfig.SetValue("message", ckmessage.Checked ? "1" : "0");
            HostSettingConfig.SetValue("messagetime", txtmessagetime.Text);
            HostSettingConfig.SetValue("compress", ckJsoncompress.Checked ? "1" : "0");
            HostSettingConfig.SetValue("encryption", ckEncryption.Checked ? "1" : "0");
            HostSettingConfig.SetValue("overtime", ckovertime.Checked ? "1" : "0");
            HostSettingConfig.SetValue("overtimetime", txtovertime.Text);
            HostSettingConfig.SaveConfig();
            isOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            txthostname.Text = HostSettingConfig.GetValue("hostname");
            ckdebug.Checked = HostSettingConfig.GetValue("debug") == "1" ? true : false;
            ckwcf.Checked = HostSettingConfig.GetValue("wcfservice") == "1" ? true : false;
            ckrouter.Checked = HostSettingConfig.GetValue("router") == "1" ? true : false;
            ckheartbeat.Checked = HostSettingConfig.GetValue("heartbeat") == "1" ? true : false;
            txtheartbeattime.Text = HostSettingConfig.GetValue("heartbeattime");
            ckmessage.Checked = HostSettingConfig.GetValue("message") == "1" ? true : false;
            txtmessagetime.Text = HostSettingConfig.GetValue("messagetime");
            ckJsoncompress.Checked = HostSettingConfig.GetValue("compress") == "1" ? true : false;
            ckEncryption.Checked = HostSettingConfig.GetValue("encryption") == "1" ? true : false;
            ckovertime.Checked = HostSettingConfig.GetValue("overtime") == "1" ? true : false;
            txtovertime.Text = HostSettingConfig.GetValue("overtimetime");
        }

    }
}
