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
    public partial class savcıkontrol : Form
    {
        public savcıkontrol()
        {
            InitializeComponent();
        }
        

            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");




        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand($"insert into dosyabilgisi(dosyano,salonID,davacıID,davalıID,avukatID,hakimID)" +
                $" values(@dosyanumber,@salon,@davacı,@davalı,@avukat,@hakim)", baglanti);

            ekleme.Parameters.AddWithValue("@dosyanumber", textBox1.Text);
            ekleme.Parameters.AddWithValue("@salon", comboBox1.Text);
            ekleme.Parameters.AddWithValue("@davacı", comboBox2.Text);
            ekleme.Parameters.AddWithValue("@davalı", comboBox3.Text);
            ekleme.Parameters.AddWithValue("@avukat", comboBox4.Text);
            ekleme.Parameters.AddWithValue("@hakim", comboBox5.Text);

            SqlCommand kt = new SqlCommand("select dosyano,salonID,davacıID,davalıID,avukatID,hakimID from dosyabilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(kt);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ekleme.ExecuteNonQuery();

            baglanti.Close();

        }

        private void savcıkontrol_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand aktar1 = new SqlCommand("select salonID  from salonbilgisi", baglanti);
            SqlDataReader adr = aktar1.ExecuteReader();

            while (adr.Read())
            {
                comboBox1.Items.Add(adr["salonID"]);
            }
            adr.Close();

            SqlCommand aktar2 = new SqlCommand("select davacıID  from davacıbilgisi", baglanti);
            SqlDataReader adr1 = aktar2.ExecuteReader();

            while (adr1.Read())
            {
                comboBox2.Items.Add(adr1["davacıID"]);
            }
            adr1.Close();

            SqlCommand aktar3= new SqlCommand("select davalıID  from davalıbilgisi", baglanti);
            SqlDataReader adr2 = aktar3.ExecuteReader();

            while (adr2.Read())
            {
                comboBox3.Items.Add(adr2["davalıID"]);
            }
            adr2.Close();

            SqlCommand aktar4= new SqlCommand("select avukatID  from avukatbilgisi", baglanti);
            SqlDataReader adr3 = aktar4.ExecuteReader();

            while (adr3.Read())
            {
                comboBox4.Items.Add(adr3["avukatID"]);
            }
            adr3.Close();


            SqlCommand aktar5= new SqlCommand("select hakimID  from hakimbilgisi", baglanti);
            SqlDataReader adr4 = aktar5.ExecuteReader();

            while (adr4.Read())
            {
                comboBox5.Items.Add(adr4["hakimID"]);
            }
            adr4.Close();
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
