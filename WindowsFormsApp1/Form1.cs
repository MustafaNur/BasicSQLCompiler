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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         
         SqlConnection baglanti1 = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=HastaneProje;Integrated Security=True");
         SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=dbRehber;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] items = { "Okul", "HastaneProje", "dbRehber" };
            comboBox1.Items.AddRange(items);
            comboBox1.SelectedItem = "Okul";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=" + comboBox1.Text +";Integrated Security=True");

            string sorgu;
            sorgu = richTextBox1.Text;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorguda bir hata var");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=" + comboBox1.Text +";Integrated Security=True");

            string sorgu = richTextBox1.Text;
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Sorguda bir hata var");
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=" + comboBox1.Text +";Integrated Security=True");
        }
    }
}
