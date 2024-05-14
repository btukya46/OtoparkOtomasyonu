using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_otomasyonu
{
    public partial class Form1 : Form
    {

        private void button2_Click(object sender, EventArgs e)
        {
            yetkili_giris yetkiligiris1 = new yetkili_giris();
            yetkiligiris1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            iletisim iletisim_form = new iletisim();
            iletisim_form.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void yetkiliGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yetkili_giris yetkiligiris1 = new yetkili_giris();
            yetkiligiris1.Show();
            this.Hide();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkimizda hakkimizda1 = new hakkimizda();
            hakkimizda1.Show();
            this.Hide();

        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iletisim iletisim_form = new iletisim();
            iletisim_form.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hakkımızdaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            anasayfa ana2 = new anasayfa(); ;
            ana2.Show();
            this.Hide();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM Kullanicilar WHERE Mail = @Mail AND Sifre = @Sifre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mail", mailTxt.Text);
                    cmd.Parameters.AddWithValue("@Sifre", sifreTxt.Text);

                    try
                    {
                        conn.Open();
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Giriş Başarılı");
                            anasayfa anasayfa1 = new anasayfa();
                            anasayfa1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Giriş Hatalı");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }

        }
    }
}
