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
    public partial class MudurYardımcısıAnaSayfa : Form
    {
        public MudurYardımcısıAnaSayfa()
        {
            InitializeComponent();
        }

        private void geriBTN_Click(object sender, EventArgs e)
        {
            yetkili_giris yetkili_Giris = new yetkili_giris();
            yetkili_Giris.Show();
            this.Hide();
        }

        private void hesapOlusturBTN_Click(object sender, EventArgs e)
        {
            string ad = adTxt.Text;
            string soyad = soyadTxt.Text;
            string telefon = telefonTxt.Text;
            string adres = adresTxt.Text;
            string cinsiyet = cinsiyetTxt.Text;
            string kullaniciAdi = kullaniciAdiTxt.Text;
            string sifre = sifreTxt.Text;

            // Giriş alanlarının dolu olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(telefon) || string.IsNullOrWhiteSpace(adres) || string.IsNullOrWhiteSpace(cinsiyet) || string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer bir veya daha fazla alan boşsa, işlemi durdur
            }

            // Kullanıcı adının benzersiz olup olmadığını kontrol et
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
            string queryCheckUsername = "SELECT COUNT(*) FROM PersonelGirisi WHERE KullaniciAdi = @KullaniciAdi";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmdCheckUsername = new SqlCommand(queryCheckUsername, conn))
                {
                    cmdCheckUsername.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                    try
                    {
                        conn.Open();
                        int count = (int)cmdCheckUsername.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor. Lütfen farklı bir kullanıcı adı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı adı kontrolü sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Eğer kullanıcı adı benzersizse, kullanıcıyı veritabanına ekle
                string queryInsertUser = "INSERT INTO PersonelGirisi (Ad, Soyad, Telefon, Adres, Cinsiyet, KullaniciAdi, Sifre) VALUES (@Ad, @Soyad, @Telefon, @Adres, @Cinsiyet, @KullaniciAdi, @Sifre)";

                using (SqlCommand cmdInsertUser = new SqlCommand(queryInsertUser, conn))
                {
                    cmdInsertUser.Parameters.AddWithValue("@Ad", ad);
                    cmdInsertUser.Parameters.AddWithValue("@Soyad", soyad);
                    cmdInsertUser.Parameters.AddWithValue("@Telefon", telefon);
                    cmdInsertUser.Parameters.AddWithValue("@Adres", adres);
                    cmdInsertUser.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                    cmdInsertUser.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmdInsertUser.Parameters.AddWithValue("@Sifre", sifre);

                    try
                    {
                        int rowsAffected = cmdInsertUser.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Personel başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Personel eklenirken bir hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Personel eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MudurYardımcısıAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = kullaniciAdiTxt.Text;

            // Kullanıcı adının dolu olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                MessageBox.Show("Lütfen kullanıcı adını girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer kullanıcı adı boşsa, işlemi durdur
            }

            // Kullanıcı adının mevcut olup olmadığını kontrol et
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
            string queryCheckUsername = "SELECT COUNT(*) FROM PersonelGirisi WHERE KullaniciAdi = @KullaniciAdi";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmdCheckUsername = new SqlCommand(queryCheckUsername, conn))
                {
                    cmdCheckUsername.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                    try
                    {
                        conn.Open();
                        int count = (int)cmdCheckUsername.ExecuteScalar();
                        if (count > 0)
                        {
                            // Kullanıcı adı mevcut ise, kullanıcıyı sil
                            string queryDeleteUser = "DELETE FROM PersonelGirisi WHERE KullaniciAdi = @KullaniciAdi";

                            using (SqlCommand cmdDeleteUser = new SqlCommand(queryDeleteUser, conn))
                            {
                                cmdDeleteUser.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                                int rowsAffected = cmdDeleteUser.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Kullanıcı başarıyla silindi.");
                                    kullaniciAdiTxt.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı silinirken bir hata oluştu.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu kullanıcı adına sahip bir kullanıcı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı adı kontrolü sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

        }
    }
}
