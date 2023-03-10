using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forwarder
{
    public partial class FTransmission : Form
    {
        private static readonly Dictionary<Transmission, FTransmission> fmap = new Dictionary<Transmission, FTransmission>();
        private static readonly Font fontMonospace = new Font("Lucida Console", 8f);
        private static readonly Font fontSmall = new Font(FontFamily.GenericSansSerif, 7f);

        private readonly Transmission trans;

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
            Text += " " + trans.Id;
        }

        public static void Execute(Transmission trans)
        {
            if (trans == null)
            {
                MessageBox.Show("Can't not load transmission, try again.");
                return;
            }
            if (!fmap.TryGetValue(trans, out FTransmission f))
                fmap[trans] = f = new FTransmission(trans);
            f.Show();
            f.Focus();
        }

        public static FTransmission Get(Transmission trans)
        {
            if (!fmap.TryGetValue(trans, out FTransmission f))
                return null;
            return f;
        }

        public void NotifyUpdate()
        {
            tUpdate.Enabled = true;
        }

        private void LoadTransmission()
        {
            if (trans == null)
                return;
            lbInfo.Text = $"Transmission between {trans.SourceIP} and {trans.DestinationIP}";
            lbAt.Text = trans.Date.ToLongDateString() + " " + trans.Date.ToLongTimeString();
            lbCtt.Text = $"Uploaded: {Utils.FBytes(trans.Uploaded)} Downloaded: {Utils.FBytes(trans.Downloaded)}";
            int cscroll = pTimeline.VerticalScroll.Value;
            pTimeline.VerticalScroll.Value = 0;
            pTimeline.Controls.Clear();
            pTimeline.SuspendLayout();
            int y = 5, w2 = (int)(pTimeline.ClientSize.Width * 0.7);
            DateTime tstart = trans.Date;
            DateTime tlast = tstart;
            foreach (Sentence s in trans.Conversation)
            {
                if ((s.Time - tlast).TotalSeconds > 5)
                {
                    Label lbx = new Label
                    {
                        Parent = pTimeline,
                        Font = fontSmall,
                        Text = "On hold by " + Utils.FTime(s.Time - tlast),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.LightGray,
                        Top = y,
                        Left = 5,
                        Width = pTimeline.ClientSize.Width - 10
                    };
                    y += lbx.Height + 15;
                }
                Label lbs = new Label
                {
                    AutoSize = true,
                    Padding = new Padding(3),
                    Top = y,
                    Width = pTimeline.ClientSize.Width / 2,
                    Left = s.FromMe ? 5 : pTimeline.ClientSize.Width - 5 - w2,
                    BackColor = s.FromMe ? Color.LightGreen : Color.LightBlue,
                    TextAlign = s.FromMe ? ContentAlignment.TopLeft : ContentAlignment.TopRight,
                    Text = s.Data.BinToTextSample(1024),
                    Font = fontMonospace,
                    Parent = pTimeline,
                    Cursor = Cursors.Hand,
                    Tag = s
                };
                lbs.Click += Lbs_Click;
                lbs.MinimumSize = lbs.MaximumSize = new Size(w2, 0);
                Label lbt = new Label
                {
                    Parent = pTimeline,
                    Font = fontSmall,
                    Text = $"At: {Utils.FTime(s.Time - tstart)}",
                    AutoSize = true,
                    Top = lbs.Top - 2
                };
                lbt.Left = s.FromMe ? w2 + 10 : lbs.Left - lbt.Width - 5;
                Label lbd = new Label
                {
                    Parent = pTimeline,
                    Font = fontSmall,
                    Text = $"Take: {Utils.FTime(s.Time - tlast)}",
                    ForeColor = SystemColors.GrayText,
                    AutoSize = true,
                    Top = lbt.Top + lbt.Height - 1
                };
                lbd.Left = s.FromMe ? w2 + 10 : lbs.Left - lbd.Width - 5;
                Label lbz = new Label
                {
                    Parent = pTimeline,
                    Font = fontSmall,
                    Text = Utils.FBytes(s.Data.Length),
                    AutoSize = true,
                    Top = lbd.Top + lbd.Height - 1
                };
                lbz.Left = s.FromMe ? w2 + 10 : lbs.Left - lbz.Width - 5;
                y += lbs.Height + 15;
                tlast = s.Time;
            }
            pTimeline.ResumeLayout();
            pTimeline.VerticalScroll.Value = cscroll;
        }

        private void Lbs_Click(object sender, EventArgs e)
        {
            if (!(sender is Label lb)) return;
            if (!(lb.Tag is Sentence s)) return;
            FData.Execute(Utils.FTime(s.Time - trans.Date), s);
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

        private void btSaveAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "*.zip|Zipped Transmission file",
                DefaultExt = ".zip",
                FileName = $"Transmission {trans.Id}.zip"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
                trans.SaveToFile(sfd.FileName);
        }
    }
}
