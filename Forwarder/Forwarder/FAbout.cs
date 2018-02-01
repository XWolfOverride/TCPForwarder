using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forwarder
{
    public partial class FAbout : Form
    {
        private FAbout()
        {
            InitializeComponent();
        }

        public static void Execute()
        {
            using (FAbout f = new FAbout())
            {
                f.ShowDialog();
            }
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
