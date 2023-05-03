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
    public partial class DAVACI : Form
    {
        public DAVACI()
        {
            InitializeComponent();
        }
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void DAVACI_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("select davacıID,davacıadi,davacısoyadi from davacıbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut2);
            DataTable tb = new DataTable();
            adr.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand veri = new SqlCommand($"insert into davacıbilgisi(davacıadi,davacısoyadi) values(@davaciname,@davacisurname)", baglanti);
            veri.Parameters.AddWithValue("@davaciname", textBox2.Text);
            veri.Parameters.AddWithValue("@davacisurname", textBox1.Text);
            veri.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("select davacıID,davacıadi,davacısoyadi from davacıbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut2);
            DataTable tb = new DataTable();
            adr.Fill(tb);
            dataGridView1.DataSource = tb;
            baglanti.Close();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silme = new SqlCommand("delete from davacıbilgisi where davacıadi=@davaciname and davacısoyadi=@davacisurname",baglanti);
            silme.Parameters.AddWithValue("@davaciname", textBox2.Text);
            silme.Parameters.AddWithValue("@davacisurname", textBox1.Text);

            SqlCommand komut2 = new SqlCommand("select davacıadi,davacısoyadi, davacıID from davacıbilgisi", baglanti);
            SqlDataAdapter adr1 = new SqlDataAdapter(komut2);
            DataTable tablo = new DataTable();
            adr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
           
            silme.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand güncelleme= new SqlCommand("update davacıbilgisi set davacıadi=@davaciname,davacısoyadi=@davacisurname where davacıID=@davaciıd", baglanti);
            güncelleme.Parameters.AddWithValue("@davaciname", textBox2.Text);
            güncelleme.Parameters.AddWithValue("@davacisurname", textBox1.Text);
            güncelleme.Parameters.AddWithValue("@davaciıd", textBox3.Text);


            SqlCommand komut2 = new SqlCommand("select davacıID,davacıadi,davacısoyadi from davacıbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut2);
            DataTable tb = new DataTable();
            adr.Fill(tb);
            dataGridView1.DataSource = tb;

            güncelleme.ExecuteNonQuery();
            baglanti.Close();
            
        }
    }
}
