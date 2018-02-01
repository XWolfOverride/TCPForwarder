namespace Forwarder
{
    partial class FAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAbout));
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbText = new System.Windows.Forms.Label();
            this.llbAuthor = new System.Windows.Forms.LinkLabel();
            this.btOk = new System.Windows.Forms.Button();
            this.lbVer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(66, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(183, 28);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "TCP Forwarder";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Forwarder.Properties.Resources.TcpForwarder;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbText
            // 
            this.lbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbText.Location = new System.Drawing.Point(12, 74);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(270, 207);
            this.lbText.TabIndex = 2;
            this.lbText.Text = resources.GetString("lbText.Text");
            // 
            // llbAuthor
            // 
            this.llbAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llbAuthor.AutoSize = true;
            this.llbAuthor.Location = new System.Drawing.Point(172, 47);
            this.llbAuthor.Name = "llbAuthor";
            this.llbAuthor.Size = new System.Drawing.Size(90, 13);
            this.llbAuthor.TabIndex = 3;
            this.llbAuthor.TabStop = true;
            this.llbAuthor.Text = "by XWolfOverride";
            this.llbAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAuthor_LinkClicked);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(288, 12);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(33, 269);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lbVer
            // 
            this.lbVer.AutoSize = true;
            this.lbVer.Location = new System.Drawing.Point(240, 27);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(22, 13);
            this.lbVer.TabIndex = 5;
            this.lbVer.Text = "1.0";
            // 
            // FAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 293);
            this.Controls.Add(this.lbVer);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.llbAuthor);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FAbout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About TCP Forwarder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.LinkLabel llbAuthor;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label lbVer;
    }
}