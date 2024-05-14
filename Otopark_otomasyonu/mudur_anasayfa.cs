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
    public partial class mudur_anasayfa : Form
    {
        public mudur_anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniHesap yeni_mudur_yardımcısı = new YeniHesap();
            yeni_mudur_yardımcısı.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yetkili_giris yetkiligiris1 = new yetkili_giris();
            yetkiligiris1.Show();
            this.Hide();

        }

        private void mudur_anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm2 = new Form1();
            frm2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PersonelAlım prsnlAlim = new PersonelAlım();
            prsnlAlim.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Ad, Soyad, Telefon, Adres, Cinsiyet, KullaniciAdi FROM MudurYardimcisiGirisi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Ad"].ToString());
                            item.SubItems.Add(reader["Soyad"].ToString());
                            item.SubItems.Add(reader["Telefon"].ToString());
                            item.SubItems.Add(reader["Adres"].ToString());
                            item.SubItems.Add(reader["Cinsiyet"].ToString());
                            item.SubItems.Add(reader["KullaniciAdi"].ToString());

                            listView1.Items.Add(item);
                        }

                        reader.Close();
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
