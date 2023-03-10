using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
    public partial class FAbout : Form
    {
        private FAbout()
        {
            InitializeComponent();
            lbVer.Text = Program.VERSION;
            GetIp();
        }

        public static void Execute()
        {
            using (FAbout f = new FAbout())
                f.ShowDialog();
        }

        private void GetIp()
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                if (item.NetworkInterfaceType != NetworkInterfaceType.Loopback && item.OperationalStatus == OperationalStatus.Up)
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            output += ip.Address.ToString() + "\r\n";
            output = output.Trim();
            if (output.Length == 0)
                lbIp.Visible = false;
            else
            {
                lbIp.Text = output;
                Height += lbIp.Height;
                lbText.Height -= lbIp.Height;
                lbIp.Top = ClientSize.Height - (lbIp.Height + 12);
            }
            lbIp.Text = output;
        }

        private void llbAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://xwolf.es/2018/02/171/");
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
