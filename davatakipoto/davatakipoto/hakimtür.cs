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
    public partial class hakimtur : Form
    {
        public hakimtur()
        {
            InitializeComponent();
        }
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into turbilgisi(turadi,dosyaID)" +
                " values(@name,@dosyano)", baglanti);

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@dosyano", comboBox1.Text);
            cmd.ExecuteNonQuery();
            
            SqlCommand komut = new SqlCommand("select turadi, dosyaID from turbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void hakimtür_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand combo = new SqlCommand("select dosyaID from dosyabilgisi", baglanti);
            SqlDataReader read = combo.ExecuteReader();
            while(read.Read())
            {
                comboBox1.Items.Add(read["dosyaID"]);
            }
            baglanti.Close();
            read.Close();
        }
    }
}
