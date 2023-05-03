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
using System.Security.Cryptography;

namespace davatakipoto
{
    public partial class hakimekleme : Form
    {
        public hakimekleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private static string Sifrele(string metin, HashAlgorithm alg)

        {

            byte[] byteDegeri = System.Text.Encoding.UTF8.GetBytes(metin);

            byte[] sifreliByte = alg.ComputeHash(byteDegeri);

            return Convert.ToBase64String(sifreliByte);

        }
        public static string MD5eDonustur(string metin)

        {

            MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();

            return Sifrele(metin, pwd);

        }
        string yenisifre;
        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into hakimbilgisi(hakimadi,hakimsoyadi,hakimkullaniciadi,hakimsifresi)" +
                " values(@name,@kullanıcısurname,@kullanıcıname,@kullanıcısifre)", baglanti);

            yenisifre = MD5eDonustur(textBox4.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@kullanıcısurname", textBox2.Text);
            cmd.Parameters.AddWithValue("@kullanıcıname", textBox3.Text);
            cmd.Parameters.AddWithValue("@kullanıcısifre", yenisifre);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("hakim bilgisi eklendi");
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

		private void hakimekleme_Load(object sender, EventArgs e)
		{

		}
	}
}
