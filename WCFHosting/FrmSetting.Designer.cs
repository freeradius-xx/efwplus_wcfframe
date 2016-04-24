namespace WCFHosting
{
    partial class FrmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckdebug = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckrouter = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txthostname = new System.Windows.Forms.TextBox();
            this.ckwcf = new System.Windows.Forms.CheckBox();
            this.ckheartbeat = new System.Windows.Forms.CheckBox();
            this.ckJsoncompress = new System.Windows.Forms.CheckBox();
            this.ckEncryption = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtheartbeattime = new System.Windows.Forms.TextBox();
            this.txtmessagetime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckmessage = new System.Windows.Forms.CheckBox();
            this.txtovertime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckovertime = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ckdebug
            // 
            this.ckdebug.AutoSize = true;
            this.ckdebug.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckdebug.Location = new System.Drawing.Point(22, 82);
            this.ckdebug.Name = "ckdebug";
            this.ckdebug.Size = new System.Drawing.Size(99, 21);
            this.ckdebug.TabIndex = 0;
            this.ckdebug.Text = "显示调试信息";
            this.ckdebug.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(246, 263);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(338, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckrouter
            // 
            this.ckrouter.AutoSize = true;
            this.ckrouter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckrouter.Location = new System.Drawing.Point(22, 126);
            this.ckrouter.Name = "ckrouter";
            this.ckrouter.Size = new System.Drawing.Size(111, 21);
            this.ckrouter.TabIndex = 3;
            this.ckrouter.Text = "开启路由器功能";
            this.ckrouter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "主机名称：";
            // 
            // txthostname
            // 
            this.txthostname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthostname.Location = new System.Drawing.Point(91, 28);
            this.txthostname.Name = "txthostname";
            this.txthostname.Size = new System.Drawing.Size(322, 23);
            this.txthostname.TabIndex = 5;
            // 
            // ckwcf
            // 
            this.ckwcf.AutoSize = true;
            this.ckwcf.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckwcf.Location = new System.Drawing.Point(22, 104);
            this.ckwcf.Name = "ckwcf";
            this.ckwcf.Size = new System.Drawing.Size(125, 21);
            this.ckwcf.TabIndex = 6;
            this.ckwcf.Text = "开启WCF服务功能";
            this.ckwcf.UseVisualStyleBackColor = true;
            // 
            // ckheartbeat
            // 
            this.ckheartbeat.AutoSize = true;
            this.ckheartbeat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckheartbeat.Location = new System.Drawing.Point(22, 147);
            this.ckheartbeat.Name = "ckheartbeat";
            this.ckheartbeat.Size = new System.Drawing.Size(123, 21);
            this.ckheartbeat.TabIndex = 7;
            this.ckheartbeat.Text = "开启心跳检测功能";
            this.ckheartbeat.UseVisualStyleBackColor = true;
            // 
            // ckJsoncompress
            // 
            this.ckJsoncompress.AutoSize = true;
            this.ckJsoncompress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckJsoncompress.Location = new System.Drawing.Point(231, 83);
            this.ckJsoncompress.Name = "ckJsoncompress";
            this.ckJsoncompress.Size = new System.Drawing.Size(101, 21);
            this.ckJsoncompress.TabIndex = 8;
            this.ckJsoncompress.Text = "开启Json压缩";
            this.ckJsoncompress.UseVisualStyleBackColor = true;
            // 
            // ckEncryption
            // 
            this.ckEncryption.AutoSize = true;
            this.ckEncryption.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckEncryption.Location = new System.Drawing.Point(231, 104);
            this.ckEncryption.Name = "ckEncryption";
            this.ckEncryption.Size = new System.Drawing.Size(99, 21);
            this.ckEncryption.TabIndex = 9;
            this.ckEncryption.Text = "开启数据加密";
            this.ckEncryption.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(170, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "间隔时间(秒)";
            // 
            // txtheartbeattime
            // 
            this.txtheartbeattime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtheartbeattime.Location = new System.Drawing.Point(250, 147);
            this.txtheartbeattime.Name = "txtheartbeattime";
            this.txtheartbeattime.Size = new System.Drawing.Size(56, 23);
            this.txtheartbeattime.TabIndex = 11;
            this.txtheartbeattime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmessagetime
            // 
            this.txtmessagetime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmessagetime.Location = new System.Drawing.Point(250, 171);
            this.txtmessagetime.Name = "txtmessagetime";
            this.txtmessagetime.Size = new System.Drawing.Size(56, 23);
            this.txtmessagetime.TabIndex = 14;
            this.txtmessagetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(170, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "间隔时间(秒)";
            // 
            // ckmessage
            // 
            this.ckmessage.AutoSize = true;
            this.ckmessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckmessage.Location = new System.Drawing.Point(22, 170);
            this.ckmessage.Name = "ckmessage";
            this.ckmessage.Size = new System.Drawing.Size(99, 21);
            this.ckmessage.TabIndex = 12;
            this.ckmessage.Text = "开启消息发送";
            this.ckmessage.UseVisualStyleBackColor = true;
            // 
            // txtovertime
            // 
            this.txtovertime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtovertime.Location = new System.Drawing.Point(250, 196);
            this.txtovertime.Name = "txtovertime";
            this.txtovertime.Size = new System.Drawing.Size(56, 23);
            this.txtovertime.TabIndex = 17;
            this.txtovertime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(170, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "超过时间(秒)";
            // 
            // ckovertime
            // 
            this.ckovertime.AutoSize = true;
            this.ckovertime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckovertime.Location = new System.Drawing.Point(22, 195);
            this.ckovertime.Name = "ckovertime";
            this.ckovertime.Size = new System.Drawing.Size(147, 21);
            this.ckovertime.TabIndex = 15;
            this.ckovertime.Text = "开启日志记录耗时方法";
            this.ckovertime.UseVisualStyleBackColor = true;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 313);
            this.Controls.Add(this.txtovertime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckovertime);
            this.Controls.Add(this.txtmessagetime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckmessage);
            this.Controls.Add(this.txtheartbeattime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckEncryption);
            this.Controls.Add(this.ckJsoncompress);
            this.Controls.Add(this.ckheartbeat);
            this.Controls.Add(this.ckwcf);
            this.Controls.Add(this.txthostname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckrouter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckdebug);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckdebug;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckrouter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txthostname;
        private System.Windows.Forms.CheckBox ckwcf;
        private System.Windows.Forms.CheckBox ckheartbeat;
        private System.Windows.Forms.CheckBox ckJsoncompress;
        private System.Windows.Forms.CheckBox ckEncryption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtheartbeattime;
        private System.Windows.Forms.TextBox txtmessagetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckmessage;
        private System.Windows.Forms.TextBox txtovertime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckovertime;
    }
}