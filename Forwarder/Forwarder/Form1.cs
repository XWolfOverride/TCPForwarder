using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Copyright(c) 2018 Iván Dominguez (XWolf Override)
//
//This software is provided 'as-is', without any express or implied
//warranty.In no event will the authors be held liable for any damages
//arising from the use of this software.
//
//Permission is granted to anyone to use this software for any purpose,
//including commercial applications, and to alter it and redistribute it
//freely, subject to the following restrictions:
//
//1. The origin of this software must not be misrepresented; you must not
//   claim that you wrote the original software.If you use this software
//   in a product, an acknowledgment in the product documentation would be
//   appreciated but is not required.
//2. Altered source versions must be plainly marked as such, and must not be
//   misrepresented as being the original software.
//3. This notice may not be removed or altered from any source distribution.

namespace Forwarder
{
    public partial class Form1 : Form
    {
        private const string CFG_FILENAME = "Forwarder.conf";
        private string cfgPath;

        public Form1()
        {
            InitializeComponent();
            Text += " " + Program.VERSION;
            cfgPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CFG_FILENAME);
            if (!LoadForwarders())
                AddForwarder();
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

        private bool LoadForwarders()
        {
            if (!File.Exists(cfgPath))
                return false;
            try
            {
                foreach (string line in File.ReadAllLines(cfgPath))
                {
                    string[] lp = line.Split(':');
                    if (lp.Length != 3 || lp[0].Length < 1)
                        continue;
                    ForwarderControl fc = AddForwarder();
                    fc.SourceLocal = lp[0][0] == '-';
                    fc.SourcePort = lp[0].Substring(1);
                    fc.DestinationHost = lp[1];
                    fc.DestinationPort = lp[2];
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SaveForwarders()
        {
            try
            {
                List<string> fws = new List<string>();
                foreach (ForwarderControl fc in lbForwarders.Items)
                    fws.Add((fc.SourceLocal ? "-" : "*") + fc.SourcePort + ":" + fc.DestinationHost + ":" + fc.DestinationPort);
                File.WriteAllLines(cfgPath, fws.ToArray());
            }
            catch { };
        }

        private ForwarderControl AddForwarder()
        {
            ForwarderControl fc = new ForwarderControl();
            fc.WhenChanged = ForwarderChagned;
            lbForwarders.SelectedIndex = lbForwarders.Items.Add(fc);
            return fc;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddForwarder();
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
                    e.Graphics.DrawString(fc.SourcePort, lbForwarders.Font, br, 38, e.Bounds.Top + 2);
                    e.Graphics.DrawString(fc.DestinationHost, lbForwarders.Font, br, 40, e.Bounds.Top + 20);
                    e.Graphics.DrawString(fc.DestinationPort, lbForwarders.Font, br, e.Bounds.Right - (2 + e.Graphics.MeasureString(fc.DestinationPort, lbForwarders.Font).Width), e.Bounds.Top + 20);
                }
            }
            e.DrawFocusRectangle();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveForwarders();
            while (lbForwarders.Items.Count > 0)
            {
                lbForwarders.SelectedIndex = 0;
                btDel_Click(sender, e);
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            FAbout.Execute();
        }

        private void lbForwarders_DoubleClick(object sender, EventArgs e)
        {
            ForwarderControl fc = lbForwarders.SelectedItem as ForwarderControl;
            if (fc == null)
                return;
            if (fc.Active)
                fc.StopForwarder();
            else
                fc.StartForwarder();
        }
    }
}
