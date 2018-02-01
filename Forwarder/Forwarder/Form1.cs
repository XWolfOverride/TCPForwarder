using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forwarder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btAdd_Click(null, null);
            LookupUI();
        }

        private void LookupUI()
        {
            btDel.Enabled = lbForwarders.SelectedItem != null;
        }

        private void ForwarderChagned()
        {
            lbForwarders.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forwarder fw = new Forwarder();
            fw.SetLocal("0.0.0.0", "8088");
            fw.SetRemote("tmed01.dlab.siemens.lab", "8000");
            fw.Activate();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ForwarderControl fc = new ForwarderControl();
            fc.WhenChanged = ForwarderChagned;
            lbForwarders.SelectedIndex = lbForwarders.Items.Add(fc);
        }

        private void lbForwarders_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookupUI();
            ForwarderControl fc = lbForwarders.SelectedItem as ForwarderControl;
            if (fc == null)
                return;
            pFord.Controls.Clear();
            pFord.Controls.Add(fc);
            fc.Dock = DockStyle.Fill;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            ForwarderControl fc = lbForwarders.SelectedItem as ForwarderControl;
            if (fc == null)
                return;
            fc.StopForwarder();
            lbForwarders.Items.Remove(fc);
            fc.Dispose();
            LookupUI();
        }

        private void lbForwarders_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && e.Index < lbForwarders.Items.Count)
            {
                ForwarderControl fc = lbForwarders.Items[e.Index] as ForwarderControl;
                if (fc != null)
                {
                    e.Graphics.DrawImage(Properties.Resources.world, 2, e.Bounds.Top + 2);
                    e.Graphics.DrawImage(fc.Active ? Properties.Resources.link_go : Properties.Resources.cross, 8, e.Bounds.Top + 6);
                    if (fc.SourceLocal)
                        e.Graphics.DrawImage(Properties.Resources.computer, e.Bounds.Right - 18, e.Bounds.Top + 2);
                    Brush br = new SolidBrush(e.ForeColor);
                    e.Graphics.DrawString(fc.SourcePort, lbForwarders.Font, br, 36, e.Bounds.Top + 2);
                    e.Graphics.DrawString(fc.DestinationHost, lbForwarders.Font, br, 40, e.Bounds.Top + 20);
                    e.Graphics.DrawString(fc.DestinationPort, lbForwarders.Font, br, e.Bounds.Right - (2 + e.Graphics.MeasureString(fc.DestinationPort, lbForwarders.Font).Width), e.Bounds.Top + 20);
                }
            }
            e.DrawFocusRectangle();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            while (lbForwarders.Items.Count>0)
            {
                lbForwarders.SelectedIndex = 0;
                btDel_Click(sender, e);
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            FAbout.Execute();
        }
    }
}
