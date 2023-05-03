using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace davatakipoto
{
    public partial class savcıseçim : Form
    {
        public savcıseçim()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            savcıkontrol frm5 = new savcıkontrol();
            this.Hide();
            frm5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hakimekleme frm6 = new hakimekleme();
            this.Hide();
            frm6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            avukat_ekle frm7 = new avukat_ekle();
            this.Hide();
            frm7.Show();
        }

		private void savcıseçim_Load(object sender, EventArgs e)
		{

		}
	}
}
