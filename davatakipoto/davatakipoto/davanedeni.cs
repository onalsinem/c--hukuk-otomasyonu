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
    public partial class davanedeni : Form
    {
        public davanedeni()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void davanedeni_Load(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand($"insert into nedenbilgisi(nedeni) values(@neden)", baglanti);
            ekleme.Parameters.AddWithValue("@neden", textBox2.Text);
            ekleme.ExecuteNonQuery();

            SqlCommand komut = new SqlCommand("select nedenID,nedeni from nedenbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            
            baglanti.Close();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from nedenbilgisi where nedeni=@nedenID", baglanti);
            sil.Parameters.AddWithValue("@nedenID", textBox1.Text);
            sil.ExecuteNonQuery();

            SqlCommand komut = new SqlCommand("select nedenID,nedeni from nedenbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            baglanti.Open();
            SqlCommand güncelle = new SqlCommand("update nedenbilgisi set nedeni=@neden where nedenID=@nedenıd", baglanti);
            güncelle.Parameters.AddWithValue("@neden", textBox2.Text);
            güncelle.Parameters.AddWithValue("@nedenıd", textBox1.Text);

            güncelle.ExecuteNonQuery();

            SqlCommand komut = new SqlCommand("select nedenID,nedeni from nedenbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
