using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forwarder
{
    public partial class FData : Form
    {
        private Sentence s;

        private FData()
        {
            InitializeComponent();
        }

        public static void Execute(string title, Sentence s)
        {
            var f = new FData();
            f.Text = title;
            f.tbData.Text = s.Data.BinToTextSample(s.Data.Length);
            f.tbData.SelectionLength = 0;
            f.s = s;
            f.Show();
            f.tbData.SelectionLength = 0;
        }

        private void btSaveAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.bin|Transaction binary";
            sfd.DefaultExt = ".bin";
            sfd.FileName = "Data.bin";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, s.Data);
            }
        }
    }
}
