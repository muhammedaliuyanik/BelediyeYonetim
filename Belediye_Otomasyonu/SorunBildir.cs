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
using System.Data.OleDb;

namespace Belediye_Otomasyonu
{
    public partial class SorunBildir : Form
    {
        public SorunBildir()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=belediye.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Sikayetler(TC_NO,SikayetTarihi,Adi,Soyadi,SikayetNedeni,Aciklama) values('" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox4.Text +"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sikayet başarıyla iletilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Sikayetler where TC_NO='" + textBox8.Text + "'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
