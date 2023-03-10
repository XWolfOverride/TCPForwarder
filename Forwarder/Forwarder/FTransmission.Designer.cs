namespace Forwarder
{
    partial class FTransmission
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
            this.components = new System.ComponentModel.Container();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbAt = new System.Windows.Forms.Label();
            this.lbCtt = new System.Windows.Forms.Label();
            this.pTimeline = new DBPanel();
            this.tUpdate = new System.Windows.Forms.Timer(this.components);
            this.btSaveAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(16, 11);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(142, 16);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "Transmission between";
            // 
            // lbAt
            // 
            this.lbAt.AutoSize = true;
            this.lbAt.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbAt.Location = new System.Drawing.Point(25, 27);
            this.lbAt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAt.Name = "lbAt";
            this.lbAt.Size = new System.Drawing.Size(18, 16);
            this.lbAt.TabIndex = 1;
            this.lbAt.Text = "at";
            // 
            // lbCtt
            // 
            this.lbCtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCtt.Location = new System.Drawing.Point(16, 43);
            this.lbCtt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCtt.Name = "lbCtt";
            this.lbCtt.Size = new System.Drawing.Size(1090, 16);
            this.lbCtt.TabIndex = 2;
            this.lbCtt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pTimeline
            // 
            this.pTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pTimeline.AutoScroll = true;
            this.pTimeline.BackColor = System.Drawing.SystemColors.Window;
            this.pTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTimeline.Location = new System.Drawing.Point(16, 63);
            this.pTimeline.Margin = new System.Windows.Forms.Padding(4);
            this.pTimeline.Name = "pTimeline";
            this.pTimeline.Size = new System.Drawing.Size(1089, 609);
            this.pTimeline.TabIndex = 3;
            this.pTimeline.Resize += new System.EventHandler(this.pTimeline_Resize);
            // 
            // tUpdate
            // 
            this.tUpdate.Interval = 1000;
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // btSaveAll
            // 
            this.btSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveAll.Location = new System.Drawing.Point(927, 679);
            this.btSaveAll.Name = "btSaveAll";
            this.btSaveAll.Size = new System.Drawing.Size(178, 34);
            this.btSaveAll.TabIndex = 4;
            this.btSaveAll.Text = "Save full transmission";
            this.btSaveAll.UseVisualStyleBackColor = true;
            this.btSaveAll.Click += new System.EventHandler(this.btSaveAll_Click);
            // 
            // FTransmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 725);
            this.Controls.Add(this.btSaveAll);
            this.Controls.Add(this.pTimeline);
            this.Controls.Add(this.lbCtt);
            this.Controls.Add(this.lbAt);
            this.Controls.Add(this.lbInfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(394, 235);
            this.Name = "FTransmission";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transmission";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FTransmission_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbAt;
        private System.Windows.Forms.Label lbCtt;
        private DBPanel pTimeline;
        private System.Windows.Forms.Timer tUpdate;
        private System.Windows.Forms.Button btSaveAll;
    }
}