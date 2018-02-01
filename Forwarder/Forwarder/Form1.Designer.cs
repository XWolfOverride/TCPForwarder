namespace Forwarder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbForwarders = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pFord = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btAbout = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbForwarders);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 372);
            this.panel1.TabIndex = 2;
            // 
            // lbForwarders
            // 
            this.lbForwarders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbForwarders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbForwarders.FormattingEnabled = true;
            this.lbForwarders.IntegralHeight = false;
            this.lbForwarders.ItemHeight = 40;
            this.lbForwarders.Location = new System.Drawing.Point(0, 0);
            this.lbForwarders.Name = "lbForwarders";
            this.lbForwarders.Size = new System.Drawing.Size(200, 335);
            this.lbForwarders.TabIndex = 1;
            this.lbForwarders.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbForwarders_DrawItem);
            this.lbForwarders.SelectedIndexChanged += new System.EventHandler(this.lbForwarders_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btAbout);
            this.panel2.Controls.Add(this.btDel);
            this.panel2.Controls.Add(this.btAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 335);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 37);
            this.panel2.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 372);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pFord
            // 
            this.pFord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFord.Location = new System.Drawing.Point(203, 0);
            this.pFord.MinimumSize = new System.Drawing.Size(300, 0);
            this.pFord.Name = "pFord";
            this.pFord.Size = new System.Drawing.Size(501, 372);
            this.pFord.TabIndex = 4;
            // 
            // btAbout
            // 
            this.btAbout.Image = global::Forwarder.Properties.Resources.help;
            this.btAbout.Location = new System.Drawing.Point(3, 6);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(26, 26);
            this.btAbout.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btAbout, "About TCP Forwarder");
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::Forwarder.Properties.Resources.world_delete;
            this.btDel.Location = new System.Drawing.Point(132, 6);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(68, 26);
            this.btDel.TabIndex = 1;
            this.btDel.Text = "Delete";
            this.btDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btDel, "Delete selected forwarder");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::Forwarder.Properties.Resources.world_add;
            this.btAdd.Location = new System.Drawing.Point(61, 6);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(65, 26);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Add";
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btAdd, "Add a forwarder");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 372);
            this.Controls.Add(this.pFord);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Forwarder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbForwarders;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pFord;
        private System.Windows.Forms.Button btDel;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btAbout;
    }
}

