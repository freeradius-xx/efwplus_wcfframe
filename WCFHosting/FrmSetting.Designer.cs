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
            this.btnOk.Location = new System.Drawing.Point(242, 211);
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
            this.btnCancel.Location = new System.Drawing.Point(334, 211);
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
            this.ckrouter.Location = new System.Drawing.Point(22, 124);
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
            this.txthostname.Size = new System.Drawing.Size(236, 23);
            this.txthostname.TabIndex = 5;
            // 
            // ckwcf
            // 
            this.ckwcf.AutoSize = true;
            this.ckwcf.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckwcf.Location = new System.Drawing.Point(22, 103);
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
            this.ckheartbeat.Location = new System.Drawing.Point(22, 144);
            this.ckheartbeat.Name = "ckheartbeat";
            this.ckheartbeat.Size = new System.Drawing.Size(123, 21);
            this.ckheartbeat.TabIndex = 7;
            this.ckheartbeat.Text = "开启心跳检测功能";
            this.ckheartbeat.UseVisualStyleBackColor = true;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 251);
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
    }
}