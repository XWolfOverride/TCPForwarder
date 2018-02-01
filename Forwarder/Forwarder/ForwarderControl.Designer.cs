﻿namespace Forwarder
{
    partial class ForwarderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForwarderControl));
            this.pConf = new System.Windows.Forms.Panel();
            this.btStart = new System.Windows.Forms.Button();
            this.tbDestPort = new System.Windows.Forms.TextBox();
            this.lbDestPort = new System.Windows.Forms.Label();
            this.tbDestHost = new System.Windows.Forms.TextBox();
            this.lbDestHost = new System.Windows.Forms.Label();
            this.cbLocal = new System.Windows.Forms.CheckBox();
            this.tbSrcPort = new System.Windows.Forms.TextBox();
            this.lbSrc = new System.Windows.Forms.Label();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilMsg = new System.Windows.Forms.ImageList(this.components);
            this.lbInfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btClear = new System.Windows.Forms.Button();
            this.rbFollow = new System.Windows.Forms.RadioButton();
            this.cbCapture = new System.Windows.Forms.CheckBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pConf.SuspendLayout();
            this.SuspendLayout();
            // 
            // pConf
            // 
            this.pConf.Controls.Add(this.cbCapture);
            this.pConf.Controls.Add(this.rbFollow);
            this.pConf.Controls.Add(this.lbInfo);
            this.pConf.Controls.Add(this.btClear);
            this.pConf.Controls.Add(this.btStart);
            this.pConf.Controls.Add(this.tbDestPort);
            this.pConf.Controls.Add(this.lbDestPort);
            this.pConf.Controls.Add(this.tbDestHost);
            this.pConf.Controls.Add(this.lbDestHost);
            this.pConf.Controls.Add(this.cbLocal);
            this.pConf.Controls.Add(this.tbSrcPort);
            this.pConf.Controls.Add(this.lbSrc);
            this.pConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.pConf.Location = new System.Drawing.Point(0, 0);
            this.pConf.Name = "pConf";
            this.pConf.Size = new System.Drawing.Size(424, 80);
            this.pConf.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Location = new System.Drawing.Point(360, 25);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(61, 23);
            this.btStart.TabIndex = 17;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbDestPort
            // 
            this.tbDestPort.Location = new System.Drawing.Point(306, 28);
            this.tbDestPort.Name = "tbDestPort";
            this.tbDestPort.Size = new System.Drawing.Size(48, 20);
            this.tbDestPort.TabIndex = 16;
            this.tbDestPort.Text = "8088";
            this.tbDestPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDestPort.TextChanged += new System.EventHandler(this.ConfChanged);
            // 
            // lbDestPort
            // 
            this.lbDestPort.AutoSize = true;
            this.lbDestPort.Location = new System.Drawing.Point(271, 31);
            this.lbDestPort.Name = "lbDestPort";
            this.lbDestPort.Size = new System.Drawing.Size(29, 13);
            this.lbDestPort.TabIndex = 15;
            this.lbDestPort.Text = "Port:";
            // 
            // tbDestHost
            // 
            this.tbDestHost.Location = new System.Drawing.Point(76, 29);
            this.tbDestHost.Name = "tbDestHost";
            this.tbDestHost.Size = new System.Drawing.Size(185, 20);
            this.tbDestHost.TabIndex = 14;
            this.tbDestHost.TextChanged += new System.EventHandler(this.ConfChanged);
            // 
            // lbDestHost
            // 
            this.lbDestHost.AutoSize = true;
            this.lbDestHost.Location = new System.Drawing.Point(7, 32);
            this.lbDestHost.Name = "lbDestHost";
            this.lbDestHost.Size = new System.Drawing.Size(63, 13);
            this.lbDestHost.TabIndex = 13;
            this.lbDestHost.Text = "Destination:";
            // 
            // cbLocal
            // 
            this.cbLocal.AutoSize = true;
            this.cbLocal.Location = new System.Drawing.Point(130, 5);
            this.cbLocal.Name = "cbLocal";
            this.cbLocal.Size = new System.Drawing.Size(131, 17);
            this.cbLocal.TabIndex = 12;
            this.cbLocal.Text = "only local connections";
            this.cbLocal.UseVisualStyleBackColor = true;
            this.cbLocal.CheckedChanged += new System.EventHandler(this.ConfChanged);
            // 
            // tbSrcPort
            // 
            this.tbSrcPort.Location = new System.Drawing.Point(76, 3);
            this.tbSrcPort.Name = "tbSrcPort";
            this.tbSrcPort.Size = new System.Drawing.Size(48, 20);
            this.tbSrcPort.TabIndex = 11;
            this.tbSrcPort.Text = "8088";
            this.tbSrcPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSrcPort.TextChanged += new System.EventHandler(this.ConfChanged);
            // 
            // lbSrc
            // 
            this.lbSrc.AutoSize = true;
            this.lbSrc.Location = new System.Drawing.Point(4, 6);
            this.lbSrc.Name = "lbSrc";
            this.lbSrc.Size = new System.Drawing.Size(66, 13);
            this.lbSrc.TabIndex = 10;
            this.lbSrc.Text = "Source Port:";
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(0, 80);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(424, 342);
            this.lvHistory.SmallImageList = this.ilMsg;
            this.lvHistory.TabIndex = 1;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.Resize += new System.EventHandler(this.lvHistory_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Events";
            this.columnHeader1.Width = 300;
            // 
            // ilMsg
            // 
            this.ilMsg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMsg.ImageStream")));
            this.ilMsg.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMsg.Images.SetKeyName(0, "msg_info.png");
            this.ilMsg.Images.SetKeyName(1, "msg_error.png");
            this.ilMsg.Images.SetKeyName(2, "msg_connect.png");
            this.ilMsg.Images.SetKeyName(3, "msg_go.png");
            this.ilMsg.Images.SetKeyName(4, "msg_come.png");
            this.ilMsg.Images.SetKeyName(5, "msg_finish.png");
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.Location = new System.Drawing.Point(274, 59);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(147, 16);
            this.lbInfo.TabIndex = 19;
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClear.Image = global::Forwarder.Properties.Resources.list_clear;
            this.btClear.Location = new System.Drawing.Point(1, 52);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(25, 25);
            this.btClear.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btClear, "Clear event list");
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // rbFollow
            // 
            this.rbFollow.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbFollow.Checked = true;
            this.rbFollow.Image = global::Forwarder.Properties.Resources.list_follow;
            this.rbFollow.Location = new System.Drawing.Point(28, 52);
            this.rbFollow.Name = "rbFollow";
            this.rbFollow.Size = new System.Drawing.Size(25, 25);
            this.rbFollow.TabIndex = 21;
            this.rbFollow.TabStop = true;
            this.toolTip1.SetToolTip(this.rbFollow, "Follow events");
            this.rbFollow.UseVisualStyleBackColor = true;
            // 
            // cbCapture
            // 
            this.cbCapture.AutoSize = true;
            this.cbCapture.Enabled = false;
            this.cbCapture.Location = new System.Drawing.Point(59, 57);
            this.cbCapture.Name = "cbCapture";
            this.cbCapture.Size = new System.Drawing.Size(87, 17);
            this.cbCapture.TabIndex = 22;
            this.cbCapture.Text = "Capture data";
            this.toolTip1.SetToolTip(this.cbCapture, "Capture traffic data for later analysis");
            this.cbCapture.UseVisualStyleBackColor = true;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Send";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Recv.";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 70;
            // 
            // ForwarderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.pConf);
            this.Name = "ForwarderControl";
            this.Size = new System.Drawing.Size(424, 422);
            this.pConf.ResumeLayout(false);
            this.pConf.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pConf;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbDestPort;
        private System.Windows.Forms.Label lbDestPort;
        private System.Windows.Forms.TextBox tbDestHost;
        private System.Windows.Forms.Label lbDestHost;
        private System.Windows.Forms.CheckBox cbLocal;
        private System.Windows.Forms.TextBox tbSrcPort;
        private System.Windows.Forms.Label lbSrc;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList ilMsg;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rbFollow;
        private System.Windows.Forms.CheckBox cbCapture;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}