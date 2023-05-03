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
    public partial class davasalonu : Form
    {
        public davasalonu()
        {
            InitializeComponent();
        }
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand($"insert into salonbilgisi(salonadi) values(@name) where salonID=@salonıd", baglanti);
            ekleme.Parameters.AddWithValue("@name", textBox2.Text);
            ekleme.Parameters.AddWithValue("@salonıd", textBox1.Text);


            SqlCommand komut = new SqlCommand("select salonID,salonadi from salonbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            ekleme.ExecuteNonQuery();
            baglanti.Close();
            

        }

        private void davasalonu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from salonbilgisi where salonadi=@name,salonID=@salonıd", baglanti);
            sil.Parameters.AddWithValue("@name", textBox2.Text);
            sil.Parameters.AddWithValue("@salonıd", textBox1.Text);


            SqlCommand komut = new SqlCommand("select salonID,salonadi from salonbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            baglanti.Close();
            sil.ExecuteNonQuery();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand güncelle = new SqlCommand("update salonbilgisi set salonadi=@name where salonID=@salonıd", baglanti);
            güncelle.Parameters.AddWithValue("@name", textBox2.Text);
            güncelle.Parameters.AddWithValue("@salonıd", textBox1.Text);


            SqlCommand komut = new SqlCommand("select salonID, salonadi from salonbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            baglanti.Close();
            güncelle.ExecuteNonQuery();
           
        }
    }
}
