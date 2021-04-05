using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BelediyeYonetim
{
    public partial class Form2 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=belediye.mdb");
        OleDbCommand komut = new OleDbCommand();
        public Form2()
        {
            InitializeComponent();
            
        }
        public void verileri_guncelle()
        {
            baglanti.Open();
            komut = new OleDbCommand("Select KullaniciAdi,Sifre,Tc from Personel", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox21.Text = dr["KullaniciAdi"].ToString();
                textBox22.Text = dr["Sifre"].ToString();
                textBox23.Text = dr["Tc"].ToString();

            }
            baglanti.Close();
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button4, "YENİ KİŞİ EKLEMEK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button5, "KİŞİLERİ SORGULAMA/BELGELEME İÇİN TIKLAYIN");
            aciklama.SetToolTip(button7, "FATURA İŞLEMLERİ İÇİN TIKLAYIN");
            verileri_guncelle();


        }
 
        private void timer1_Tick(object sender, EventArgs e)// TİMER
                {
                    DateTime dt = DateTime.Now;
                    label1.Text = dt.ToLongDateString();
                    label2.Text = dt.ToLongTimeString();
                }
        private void button4_Click(object sender, EventArgs e)// KİŞİ EKLEME BUTONU
                {
                    Form4 frm4 = new Form4();
                    frm4.ShowDialog();
                }


        private void button7_Click(object sender, EventArgs e)// FATURA İŞLEMLERİ
                {
                    Form7 frm7 = new Form7();
                    frm7.ShowDialog();

                }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)// FORM2 CLOSİNG OLAYI
                {
                    Application.Exit();
                }


        private void button10_Click(object sender, EventArgs e)//Değişiklikleri kaydet butonu
        {
            baglanti.Open();
            if(textBox23.Text == "")
            {
               
                komut = new OleDbCommand("update Personel set KullaniciAdi='" + textBox21.Text + "', Sifre='" + textBox22.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler Kayıt Edildi.");
                baglanti.Close();
            }
            else if(textBox23.Text != "")
            {
                komut = new OleDbCommand("update Persoenl set KullaniciAdi='" + textBox21.Text + "', Sifre='" + textBox22.Text + "', Tc='"+textBox23.Text+"'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler Kayıt Edildi.");
                baglanti.Close();
            }
        }

      

        private void button10_Click_1(object sender, EventArgs e)
        {
            verileri_guncelle();
            groupBox4.Visible = false;
            label5.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Belediye_Otomasyonu.KisiBul KisiBul1 = new Belediye_Otomasyonu.KisiBul();
            KisiBul1.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            verileri_guncelle();
            groupBox5.Visible = true;
            label5.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Belediye_Otomasyonu.SorunBildir sorunBildir1 = new Belediye_Otomasyonu.SorunBildir();
            sorunBildir1.ShowDialog();
        }
    }
}
