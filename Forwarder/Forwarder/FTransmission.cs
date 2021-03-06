﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forwarder
{
    public partial class FTransmission : Form
    {
        private static Dictionary<Transmission, FTransmission> fmap = new Dictionary<Transmission, FTransmission>();
        private static Font fontMonospace = new Font("Lucida Console", 7.5f);
        private static Font fontSmall = new Font(FontFamily.GenericSansSerif, 6f);

        private Transmission trans;

        private FTransmission(Transmission trans)
        {
            InitializeComponent();
            this.trans = trans;
            LoadTransmission();
            pTimeline.AutoScroll = false;
            pTimeline.HorizontalScroll.Enabled = false;
            pTimeline.HorizontalScroll.Visible = false;
            pTimeline.HorizontalScroll.Maximum = 0;
            pTimeline.AutoScroll = true;
        }

        public static void Execute(Transmission trans)
        {
            FTransmission f;
            if (!fmap.TryGetValue(trans, out f))
                fmap[trans] = f = new FTransmission(trans);
            f.Show();
            f.Focus();
        }

        public static FTransmission Get(Transmission trans)
        {
            FTransmission f;
            if (!fmap.TryGetValue(trans, out f))
                return null;
            return f;
        }

        public void NotifyUpdate()
        {
            tUpdate.Enabled = true;
        }

        private void LoadTransmission()
        {
            lbInfo.Text = "Transmission between " + trans.SourceIP + " and " + trans.DestinationIP;
            lbAt.Text = trans.Date.ToLongDateString() + " " + trans.Date.ToLongTimeString();
            lbCtt.Text = "Uploaded: " + Utils.FBytes(trans.Uploaded) + " Downloaded: " + Utils.FBytes(trans.Downloaded);
            int cscroll = pTimeline.VerticalScroll.Value;
            pTimeline.VerticalScroll.Value = 0;
            pTimeline.Controls.Clear();
            pTimeline.SuspendLayout();
            int y = 5, w2 = (int)(pTimeline.ClientSize.Width * 0.7);
            DateTime tstart = trans.Date;
            DateTime tlast = tstart;
            foreach (Sentence s in trans.Conversation)
            {
                if ((s.Time - tlast).TotalSeconds > 30)
                {
                    Label lbx = new Label();
                    lbx.Parent = pTimeline;
                    lbx.Font = fontSmall;
                    lbx.Text = "On hold by " + Utils.FTime(s.Time - tlast);
                    lbx.TextAlign = ContentAlignment.MiddleCenter;
                    lbx.BackColor = Color.LightYellow;
                    lbx.Top = y;
                    lbx.Left = 5;
                    lbx.Width = pTimeline.ClientSize.Width - 10;
                    y += lbx.Height + 4;
                }
                Label lbs = new Label();
                lbs.AutoSize = true;
                lbs.MinimumSize = lbs.MaximumSize = new Size(w2, 0);
                lbs.Padding = new Padding(3);
                lbs.Top = y;
                lbs.Width = pTimeline.ClientSize.Width / 2;
                lbs.Left = s.FromMe ? 5 : pTimeline.ClientSize.Width - 5 - w2;
                lbs.BackColor = s.FromMe ? Color.LightGreen : Color.LightBlue;
                lbs.TextAlign = s.FromMe ? ContentAlignment.TopLeft : ContentAlignment.TopRight;
                lbs.Text = Utils.BinToTextSample(s.Data);
                lbs.Font = fontMonospace;
                lbs.Parent = pTimeline;
                Label lbt = new Label();
                lbt.Parent = pTimeline;
                lbt.Font = fontSmall;
                lbt.Text = Utils.FTime(s.Time - tstart);
                lbt.AutoSize = true;
                lbt.Top = lbs.Top - 2;
                lbt.Left = s.FromMe ? w2 + 10 : lbs.Left - lbt.Width - 5;
                Label lbd = new Label();
                lbd.Parent = pTimeline;
                lbd.Font = fontSmall;
                lbd.Text = Utils.FTime(s.Time - tlast);
                lbd.ForeColor = SystemColors.GrayText;
                lbd.AutoSize = true;
                lbd.Top = lbt.Top + lbt.Height - 1;
                lbd.Left = s.FromMe ? w2 + 10 : lbs.Left - lbd.Width - 5;
                Label lbz = new Label();
                lbz.Parent = pTimeline;
                lbz.Font = fontSmall;
                lbz.Text = Utils.FBytes(s.Data.Length);
                lbz.AutoSize = true;
                lbz.Top = lbd.Top + lbd.Height - 1;
                lbz.Left = s.FromMe ? w2 + 10 : lbs.Left - lbz.Width - 5;
                y += lbs.Height + 4;
                tlast = s.Time;
            }
            pTimeline.ResumeLayout();
            pTimeline.VerticalScroll.Value = cscroll;
        }

        private void FTransmission_FormClosed(object sender, FormClosedEventArgs e)
        {
            fmap.Remove(trans);
            Dispose();
        }

        private void pTimeline_Resize(object sender, EventArgs e)
        {
            LoadTransmission();
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            tUpdate.Enabled = false;
            LoadTransmission();
        }
    }
}
