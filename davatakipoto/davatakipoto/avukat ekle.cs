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
    public partial class avukat_ekle : Form
    {
        public avukat_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void avukat_ekle_Load(object sender, EventArgs e)
        {

        }
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
            
            baglan.Open();
            SqlCommand cmd = new SqlCommand("insert into avukatbilgisi(avukatadi,avukatsoyadi,avukatkullanıcıadi,avukatsifresi)" +
                " values(@name,@kullanıcısurname,@kullanıcıname,@kullanıcısifre)", baglan);
            yenisifre = MD5eDonustur(textBox4.Text);

            cmd.Parameters.AddWithValue("@name",textBox1.Text);
            cmd.Parameters.AddWithValue("@kullanıcısurname", textBox3.Text);
            cmd.Parameters.AddWithValue("@kullanıcıname", textBox2.Text);
            cmd.Parameters.AddWithValue("@kullanıcısifre", yenisifre);
            //cmd.Parameters.AddWithValue("@buroname", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("avukat bilgisi eklendi");
            baglan.Close();
        }
    }
}
