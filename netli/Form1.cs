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
using System.Data;
using System.Windows.Forms;

namespace netli
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
           
        }
        void OgrenciGetir()
        { 
           
            con = new SqlConnection("server=.;Initial Catalog=FEHMİTD;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM ogrenciler", con);
            DataTable tablo =new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        OgrenciGetir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)//DATAGRİDVİEW GÖRÜNTÜLEME KISMI
        {
            txtNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtIsim.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSehir.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)//EKLEME BUTONU
        {
            string sorgu = "INSERT INTO ogrenciler(ogr_no,ogr_ad,ogr_soyad,ogr_sehir)VALUES(@ogr_no,@ogr_ad,@ogr_soyad,@ogr_sehir)";
            cmd=new SqlCommand(sorgu,con);
            cmd.Parameters.AddWithValue("@ogr_no", txtNo.Text);
            cmd.Parameters.AddWithValue("@ogr_ad", txtIsim.Text);
            cmd.Parameters.AddWithValue("@ogr_soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@ogr_sehir", txtSehir.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            OgrenciGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)//SİLME BUTONU
        {
            String sorgu = "DELETE FROM ogrenciler WHERE ogr_no=@ogr_no";
            cmd = new SqlCommand(sorgu,con);
            cmd.Parameters.AddWithValue("@ogr_no",Convert.ToInt32(txtNo.Text));
            con.Open() ;
            cmd.ExecuteNonQuery();
            con.Close();
            OgrenciGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)//GÜNCELLE BUTONU
        {
            String sorgu = "UPDATE ogrenciler SET ogr_ad=@ogr_ad,ogr_soyad=@ogr_soyad,ogr_sehir=@ogr_sehir WHEREO ogr_no=@ogr_no)";
            cmd=new SqlCommand(sorgu,con);
            cmd.Parameters.AddWithValue("@ogr_no", txtNo.Text);
            cmd.Parameters.AddWithValue("@ogr_ad", txtIsim.Text);
            cmd.Parameters.AddWithValue("@ogr_soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@ogr_sehir", txtSehir.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            OgrenciGetir();
        }
    }
}
