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
    public partial class KisiBul : Form
    {
        public KisiBul()
        {
            InitializeComponent();
            
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=belediye.mdb");
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from kisibilgiler where TC_NO like '%" + textBox1.Text + "%'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
