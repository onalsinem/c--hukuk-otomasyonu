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
    public partial class davalı : Form
    {
        public davalı()
        {
            InitializeComponent();
        }
        
        private void davalı_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JQVRP07\\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand ekle2 = new SqlCommand($"insert into davalıbilgisi(davalıadi,davalısoyadi,davaID) values(@davalıname,@davalısurname,@davaıd)", baglanti);
            ekle2.Parameters.AddWithValue("@davalıname", textBox2.Text);
            ekle2.Parameters.AddWithValue("@davalısurname", textBox1.Text);
            ekle2.Parameters.AddWithValue("@davaıd", textBox3.Text);

            SqlCommand cmd= new SqlCommand("select davalıadi,davalısoyadi,davaID from davalıbilgisi", baglanti);
            SqlDataAdapter adr = new SqlDataAdapter(cmd);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ekle2.ExecuteNonQuery();
            baglanti.Close();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from davalıbilgisi where davalıID=@davalııd", baglanti);
           // sil.Parameters.AddWithValue("@davalıname", textBox2.Text);
            //sil.Parameters.AddWithValue("@davalısurname", textBox1.Text);
            sil.Parameters.AddWithValue("@davalııd", textBox3.Text);

            SqlCommand cmd = new SqlCommand("select davalıadi,davalısoyadi,davaID from davalıbilgisi", baglanti);

            SqlDataAdapter adr = new SqlDataAdapter(cmd);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            sil.ExecuteNonQuery();

            baglanti.Close();
         
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand güncelle = new SqlCommand("update davalıbilgisi set davalıadi=@davaliname,davalısoyadi=@davalisurname where davaID=@davaıd", baglanti);
            güncelle.Parameters.AddWithValue("@davaliname", textBox2.Text);
            güncelle.Parameters.AddWithValue("@davalisurname", textBox1.Text);
            güncelle.Parameters.AddWithValue("@davaıd", textBox3.Text);

            SqlCommand cmd= new SqlCommand("select davalıadi,davalısoyadi,davaID from davalıbilgisi", baglanti);

            SqlDataAdapter adr = new SqlDataAdapter(cmd);
            DataTable tablo = new DataTable();
            adr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            güncelle.ExecuteNonQuery();

            baglanti.Close();
         
           
        }
    }
}
