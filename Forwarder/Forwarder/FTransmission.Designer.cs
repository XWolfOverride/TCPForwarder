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
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(12, 9);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(112, 13);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "Transmission between";
            // 
            // lbAt
            // 
            this.lbAt.AutoSize = true;
            this.lbAt.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbAt.Location = new System.Drawing.Point(19, 22);
            this.lbAt.Name = "lbAt";
            this.lbAt.Size = new System.Drawing.Size(16, 13);
            this.lbAt.TabIndex = 1;
            this.lbAt.Text = "at";
            // 
            // lbCtt
            // 
            this.lbCtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCtt.Location = new System.Drawing.Point(12, 35);
            this.lbCtt.Name = "lbCtt";
            this.lbCtt.Size = new System.Drawing.Size(360, 13);
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
            this.pTimeline.Location = new System.Drawing.Point(12, 51);
            this.pTimeline.Name = "pTimeline";
            this.pTimeline.Size = new System.Drawing.Size(360, 355);
            this.pTimeline.TabIndex = 3;
            this.pTimeline.Resize += new System.EventHandler(this.pTimeline_Resize);
            // 
            // tUpdate
            // 
            this.tUpdate.Interval = 1000;
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // FTransmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 418);
            this.Controls.Add(this.pTimeline);
            this.Controls.Add(this.lbCtt);
            this.Controls.Add(this.lbAt);
            this.Controls.Add(this.lbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FTransmission";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
    }
}