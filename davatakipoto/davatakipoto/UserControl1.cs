using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace davatakipoto
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public static string Sifrele(string metin, HashAlgorithm alg)

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

		SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            hakimtur frm1 = new hakimtur();

           

            DataTable dt = new DataTable();

            string kt = "SELECT * FROM hakimbilgisi WHERE hakimkullaniciadi=@HAKİMUSERNAME AND hakimsifresi=@HAKİMPASSWORD";

            //string yenisifre = MD5eDonustur(textBox2.Text);
            SqlParameter ekle1 = new SqlParameter("@HAKİMUSERNAME", textBox1.Text);
            SqlParameter ekle2 = new SqlParameter("@HAKİMPASSWORD", textBox2.Text);

            SqlCommand cmd = new SqlCommand(kt,baglan);
            cmd.Parameters.Add(ekle1);
            cmd.Parameters.Add(ekle2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            savcıseçim frm2 = new savcıseçim();

            DataTable dt = new DataTable();

            string komut = "SELECT * FROM savcıbilgisi WHERE savcıkullaniciadi=@savciUSERNAME AND savcısifresi=@savciPASSWORD";

            //string yenisifre = MD5eDonustur(textBox5.Text);
            SqlParameter ekle1 = new SqlParameter("@savciUSERNAME", textBox6.Text);
            SqlParameter ekle2 = new SqlParameter("@savciPASSWORD", textBox5.Text);

            SqlCommand cmd = new SqlCommand(komut, baglan);
            cmd.Parameters.Add(ekle1);
            cmd.Parameters.Add(ekle2);
            SqlDataAdapter adr= new SqlDataAdapter(cmd);
            adr.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }

            baglan.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hakimkontrol frm1 = new hakimkontrol();

            DataTable dt = new DataTable();
            baglan.Open();
            string veri = "SELECT * FROM avukatbilgisi WHERE avukatkullanıcıadi=@AVUKATUSERNAME and avukatsifresi=@AVUKATPASSWORD";

            //string yenisifre = MD5eDonustur(textBox4.Text);
            SqlParameter ekle1 = new SqlParameter("@AVUKATUSERNAME", textBox3.Text);
            SqlParameter ekle2 = new SqlParameter("@AVUKATPASSWORD", textBox4.Text);

            SqlCommand cmd= new SqlCommand(veri, baglan);
            cmd.Parameters.Add(ekle1);
            cmd.Parameters.Add(ekle2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
            baglan.Close();
        }
    }
}
