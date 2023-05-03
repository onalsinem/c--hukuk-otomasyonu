using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace davatakipoto
{
    public partial class hakimkontrol : Form
    {
        public hakimkontrol()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DAVACI frm1 = new DAVACI();
            this.Hide();
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            davalı frm3 = new davalı();
            this.Hide();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            davanedeni frm2 = new davanedeni();
            this.Hide();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            konu frm4 = new konu();
            this.Hide();
            frm4.Show();
        }
    }
}
