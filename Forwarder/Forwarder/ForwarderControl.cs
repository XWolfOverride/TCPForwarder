using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

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
    public partial class ForwarderControl : UserControl
    {
        public ForwarderChanged WhenChanged;

        Forwarder fw = new Forwarder();

        public ForwarderControl()
        {
            InitializeComponent();
            fw.WhenMessage = FMessage;
            lvHistory_Resize(null, null);
            FMessage(fw, null);
        }

        private int FMessageIcon(ForwarderMessageType t)
        {
            switch (t)
            {
                case ForwarderMessageType.ACTIVATED:
                case ForwarderMessageType.DEACTIVATED:
                    return 0;
                case ForwarderMessageType.ERROR:
                    return 1;
                case ForwarderMessageType.TSTART:
                    return 2;
                case ForwarderMessageType.TSEND:
                    return 3;
                case ForwarderMessageType.TRECV:
                    return 4;
                case ForwarderMessageType.TEND:
                    return 5;
                default:
                    return 1;
            }
        }

        private void FMessage(Forwarder sender, ForwarderMessage msg)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new MethodInvoker(() => FMessage(sender, msg)));
                }
                catch { }
                return;
            }
            ListViewItem lvi = null;
            if (msg != null)
                switch (msg.Type)
                {
                    case ForwarderMessageType.ACTIVATED:
                    case ForwarderMessageType.DEACTIVATED:
                        lvi = lvHistory.Items.Add(msg.Message);
                        lvi.ImageIndex = 0;
                        lvi.Tag = msg;
                        break;
                    case ForwarderMessageType.ERROR:
                        lvi = lvHistory.Items.Add(msg.Message);
                        lvi.ImageIndex = 1;
                        lvi.Tag = msg;
                        break;
                    case ForwarderMessageType.TSTART:
                        lvi = lvHistory.Items.Add(msg.Message);
                        lvi.ImageIndex = 2;
                        msg.Transmission.Tag = lvi;
                        lvi.SubItems.Add("0");
                        lvi.SubItems.Add("0");
                        lvi.Tag = msg;
                        break;
                    case ForwarderMessageType.TEND:
                    case ForwarderMessageType.TRECV:
                    case ForwarderMessageType.TSEND:
                        lvi = msg.Transmission.Tag as ListViewItem;
                        if (lvi == null)
                        {
                            lvi = lvHistory.Items.Add("<<< Lost transmission >>>");
                            lvi.ImageIndex = 1;
                            msg.Transmission.Tag = lvi;
                            lvi.SubItems.Add("");
                            lvi.SubItems.Add("");
                            lvi.Tag = msg;
                        }
                        lvi.ImageIndex = FMessageIcon(msg.Type);
                        lvi.SubItems[1].Text = Utils.FBytes(msg.Transmission.Uploaded);
                        lvi.SubItems[2].Text = Utils.FBytes(msg.Transmission.Downloaded);
                        FTransmission.Get(msg.Transmission)?.NotifyUpdate();
                        break;
                    default:
                        lvi = lvHistory.Items.Add("[??] " + msg.Message);
                        lvi.ImageIndex = 1;
                        break;
                }
            if (lvi != null)
            {
                lvi.Tag = msg.Transmission;
                if (rbFollow.Checked)
                    lvi.Selected = true;
                //lvHistory_Resize(null, null);
            }
            lbInfo.Text = "Hints: " + sender.TotalConnections + " Alive: " + sender.CurrentConnections;
        }

        private bool RefreshForwarder()
        {
            try
            {
                fw.SetLocal(cbLocal.Checked ? "127.0.0.1" : "0.0.0.0", tbSrcPort.Text);
                tbSrcPort.BackColor = SystemColors.Window;
            }
            catch (FormatException)
            {
                tbSrcPort.BackColor = Color.LightPink;
                return false;
            }
            try
            {
                fw.SetRemote(tbDestHost.Text, tbDestPort.Text);
                tbDestHost.BackColor = SystemColors.Window;
                tbDestPort.BackColor = SystemColors.Window;
            }
            catch (FormatException)
            {
                tbDestPort.BackColor = Color.LightPink;
                return false;
            }
            catch (SocketException)
            {
                tbDestHost.BackColor = Color.LightPink;
                return false;
            }
            return true;
        }

        public void StartForwarder()
        {
            try
            {
                pConf.Enabled = false;
                if (!RefreshForwarder())
                {
                    pConf.Enabled = true;
                    return;
                }
                pConf.Enabled = true;

                fw.Activate();
                tbDestHost.Enabled = false;
                tbDestPort.Enabled = false;
                tbSrcPort.Enabled = false;
                cbLocal.Enabled = false;
                btStart.Text = "Stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WhenChanged?.Invoke();
        }

        public void StopForwarder()
        {
            try
            {
                fw.Deactivate();
                tbDestHost.Enabled = true;
                tbDestPort.Enabled = true;
                tbSrcPort.Enabled = true;
                cbLocal.Enabled = true;
                btStart.Text = "Start";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WhenChanged?.Invoke();
        }

        public override string ToString()
        {
            return fw.ToString();
        }

        public string SourcePort { get => tbSrcPort.Text; set => tbSrcPort.Text = value; }
        public bool SourceLocal { get => cbLocal.Checked; set => cbLocal.Checked = value; }
        public string DestinationPort { get => tbDestPort.Text; set => tbDestPort.Text = value; }
        public string DestinationHost { get => tbDestHost.Text; set => tbDestHost.Text = value; }
        public bool Active => fw.Active;

        private void btStart_Click(object sender, EventArgs e)
        {
            if (fw.Active)
                StopForwarder();
            else
                StartForwarder();
        }

        private void ConfChanged(object sender, EventArgs e)
        {
            WhenChanged?.Invoke();
        }

        private void lvHistory_Resize(object sender, EventArgs e)
        {
            int acw = 0;
            for (int i = 1; i < lvHistory.Columns.Count; i++)
                acw += lvHistory.Columns[i].Width;
            lvHistory.Columns[0].Width = lvHistory.ClientRectangle.Width - acw;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            // Bread cycling references (Make life easy for c#)
            foreach (ListViewItem lvi in lvHistory.Items)
                lvi.Tag = null;
            lvHistory.Items.Clear();
            fw.ResetCounter();
        }

        private void lvHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lvHistory.SelectedItems.Count < 0)
                return;
            Transmission t = lvHistory.SelectedItems[0].Tag as Transmission;
            if (t == null)
                return;
            FTransmission.Execute(t);
        }
    }

    public delegate void ForwarderChanged();
}
