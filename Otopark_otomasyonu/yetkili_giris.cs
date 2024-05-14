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
    public partial class yetkili_giris : Form
    {
        public yetkili_giris()
        {
            InitializeComponent();
        }

        private void yetkili_giris_Load(object sender, EventArgs e)
        {

        }

        private void müdürYardımcısıGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void müdürToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void müdürToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void geriBTN_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void OturumBTN_Click(object sender, EventArgs e)
        {

            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM MudurGirisi WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", mailTxt.Text);
                    cmd.Parameters.AddWithValue("@Sifre", sifreTxt.Text);

                    try
                    {
                        conn.Open();
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Giriş Başarılı");
                            mudur_anasayfa mudur_anasayfa = new mudur_anasayfa();
                            mudur_anasayfa.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                            mailTxt.Clear();
                            sifreTxt.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void mdr_Oturum_BTN_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM MudurYardimcisiGirisi WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);

                    try
                    {
                        conn.Open();
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Giriş Başarılı");
                            MudurYardımcısıAnaSayfa  yardimci_anasayfa = new MudurYardımcısıAnaSayfa();
                            yardimci_anasayfa.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                            mailTxt.Clear();
                            sifreTxt.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void personel_Oturum_BTN_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM PersonelGirisi WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Sifre", textBox4.Text);

                    try
                    {
                        conn.Open();
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Giriş Başarılı");
                            anasayfa anasayfa = new anasayfa();
                            anasayfa.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                            mailTxt.Clear();
                            sifreTxt.Clear();
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
