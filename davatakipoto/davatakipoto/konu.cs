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
    public partial class konu : Form
    {
        public konu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void konu_Load(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand($"insert into konubilgisi(konuadi) values (@name)", baglanti);
            ekleme.Parameters.AddWithValue("@name", textBox2.Text);

            SqlCommand komut1 = new SqlCommand("select konuadi,konuID from konubilgisi", baglanti);
            SqlDataAdapter ad = new SqlDataAdapter(komut1);
            DataTable tablo = new DataTable();
            ad.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ekleme.ExecuteNonQuery();
            baglanti.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
      
            baglanti.Open();
          SqlCommand sil = new SqlCommand("delete from konubilgisi where konuadi=@name and konuID=@konuıd", baglanti);
            sil.Parameters.AddWithValue("@name", textBox2.Text);
            sil.Parameters.AddWithValue("@konuıd", textBox1.Text);
            

            SqlCommand komut = new SqlCommand("select konuID,konuadi from konubilgisi", baglanti);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            ad.Fill(tablo);
            dataGridView1.DataSource = tablo;
          
            sil.ExecuteNonQuery();
            baglanti.Close();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand güncelleme = new SqlCommand("update konubilgisi set konuadi=@name where konuID=@konuıd", baglanti);
            güncelleme.Parameters.AddWithValue("@name", textBox2.Text);
            güncelleme.Parameters.AddWithValue("@konuıd", textBox1.Text);


            SqlCommand komut = new SqlCommand("select konuID, konuadi from konubilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tb = new DataTable();
            adr.Fill(tb);
            dataGridView1.DataSource = tb;

            güncelleme.ExecuteNonQuery();

            baglanti.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
