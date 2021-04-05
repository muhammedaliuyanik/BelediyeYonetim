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
    public partial class Form1 : Form
    {
   
        
        public Form1()
        {
            InitializeComponent();
        }
        public int bot_kontrol;
        Random rnd = new Random();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=belediye.mdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox3.Text = "Onay Kodu...";
            bot_kontrol = rnd.Next(10000, 95000);
            label4.Text = bot_kontrol.ToString();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "Giriş Yap");
            aciklama.SetToolTip(button3, "Onay Kodunu Yenile");


        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = "";
            bot_kontrol = rnd.Next(10000, 95000);
            label4.Text = bot_kontrol.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Personel where KullaniciAdi='" + textBox1.Text + "' and Sifre='" + textBox2.Text + "'",baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if(dr.Read() && (textBox3.Text == label4.Text)) // Doğrulama kodu kontrol
            {
                baglanti.Close();
                MessageBox.Show("Kullanıcı girişi doğrulandı.", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı, şifre veya güvenlik kodunda hata !");
                baglanti.Close();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {       // kullanıcı adı ve şifreyi kayıt etmek için
            if(checkBox1.Checked)
            {
                Belediye_Otomasyonu.Properties.Settings.Default.K_adi = textBox1.Text;
                Belediye_Otomasyonu.Properties.Settings.Default.Sifre = textBox2.Text;
                Belediye_Otomasyonu.Properties.Settings.Default.Save();
            }
            else
            {
                Belediye_Otomasyonu.Properties.Settings.Default.K_adi = null;
                Belediye_Otomasyonu.Properties.Settings.Default.Sifre = null;
                Belediye_Otomasyonu.Properties.Settings.Default.Save();
            }
        }
             
 
    
        private void button18_Click(object sender, EventArgs e)//admin şifre sıfırla butonu
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select Tc from Personel", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                if (textBox4.Text == dr["Tc"].ToString())
                {
                    groupBox2.Visible = false;
                    MessageBox.Show("Kullanıcı Ayarlarından şifrenizi değiştirmeyi unutmayın.");
                    Form2 frm2 = new Form2();
                    this.Hide();
                    frm2.ShowDialog();
                }
                else if (textBox4.Text != dr["Tc"].ToString())
                {
                    MessageBox.Show("Böyle bir TC Kimlik numarası bulunamadı. Lütfen tekrar deneyiniz.");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Tc kimlik alanı boş bırakılamaz!");
                }
            }
            baglanti.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
    }
}
