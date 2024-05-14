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
    public partial class YeniHesap : Form
    {
        public YeniHesap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mudur_anasayfa m_anasayfa = new mudur_anasayfa();
            m_anasayfa.Show();
            this.Hide();
        }

        private void hesapOlusturBTN_Click(object sender, EventArgs e)
        {
            // TextBox, ComboBox ve diğer giriş alanlarından verileri al
            string ad = adTxt.Text;
            string soyad = soyadTxt.Text;
            string telefon = telefonTxt.Text;
            string adres = adresTxt.Text;
            string cinsiyet = comboBox1.SelectedItem?.ToString(); // ComboBox'tan seçili öğeyi al
            string kullaniciAdi = kullaniciAdiTxt.Text;
            string sifre = sifreTxt.Text;

            // Giriş alanlarının dolu olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(telefon) || string.IsNullOrWhiteSpace(adres) || string.IsNullOrWhiteSpace(cinsiyet) || string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer bir veya daha fazla alan boşsa, işlemi durdur
            }

            // Veritabanı bağlantı dizesi
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            // Veritabanı bağlantısını oluştur
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Veritabanı sorgusu
                string query = @"INSERT INTO MudurYardimcisiGirisi (Ad, Soyad, Telefon, Adres, Cinsiyet, KullaniciAdi, Sifre) 
                     VALUES (@Ad, @Soyad, @Telefon, @Adres, @Cinsiyet, @KullaniciAdi, @Sifre)";

                // Kontrol için sorgu
                string kontrolSorgusu = "SELECT COUNT(*) FROM MudurYardimcisiGirisi WHERE KullaniciAdi = @KullaniciAdi";

                // SqlCommand nesnesini oluştur
                using (SqlCommand cmdKontrol = new SqlCommand(kontrolSorgusu, conn))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.Parameters.AddWithValue("@Adres", adres);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    // Kullanıcı adı kontrolü için parametre ekle
                    cmdKontrol.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                    try
                    {
                        // Veritabanı bağlantısını aç
                        conn.Open();

                        // Kullanıcı adı var mı kontrol et
                        int kullaniciSayisi = (int)cmdKontrol.ExecuteScalar();

                        if (kullaniciSayisi > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor. Lütfen farklı bir kullanıcı adı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Sorguyu çalıştır ve etkilenen satır sayısını al
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Etkilenen satır sayısına göre mesaj göster
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla eklendi.");
                            // Giriş alanlarını temizle
                            adTxt.Clear();
                            soyadTxt.Clear();
                            telefonTxt.Clear();
                            adresTxt.Clear();
                            comboBox1.SelectedIndex = -1; // ComboBox seçimini temizle
                            kullaniciAdiTxt.Clear();
                            sifreTxt.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Veri eklenirken bir hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanına erişirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı adını al
            string kullaniciAdi = kullaniciAdiTxt.Text;

            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";


            // Kullanıcı adının veritabanında mevcut olup olmadığını kontrol etmek için sorgu
            string kontrolSorgusu = "SELECT COUNT(*) FROM MudurYardimcisiGirisi WHERE KullaniciAdi = @KullaniciAdi";

            // Veritabanı bağlantısını oluştur
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmdKontrol = new SqlCommand(kontrolSorgusu, conn))
            {
                // Kullanıcı adı parametresini ekleyin
                cmdKontrol.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                try
                {
                    // Veritabanı bağlantısını aç
                    conn.Open();

                    // Kullanıcı adının varlığını kontrol et
                    int kullaniciSayisi = (int)cmdKontrol.ExecuteScalar();

                    if (kullaniciSayisi == 0)
                    {
                        MessageBox.Show("Silinecek kullanıcı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Silme işlemi için sorgu
                    string silmeSorgusu = "DELETE FROM MudurYardimcisiGirisi WHERE KullaniciAdi = @KullaniciAdi";

                    // Silme işlemi için SqlCommand nesnesini oluştur
                    using (SqlCommand cmdSil = new SqlCommand(silmeSorgusu, conn))
                    {
                        // Kullanıcı adı parametresini ekleyin
                        cmdSil.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                        try
                        {
                            // Silme işlemini gerçekleştir
                            int rowsAffectedSil = cmdSil.ExecuteNonQuery();

                            // Etkilenen satır sayısına göre mesaj göster
                            if (rowsAffectedSil > 0)
                            {
                                MessageBox.Show("Kullanıcı başarıyla silindi.");
                                // Giriş alanlarını temizle
                                adTxt.Clear();
                                soyadTxt.Clear();
                                telefonTxt.Clear();
                                adresTxt.Clear();
                                kullaniciAdiTxt.Clear();
                                comboBox1.SelectedIndex = -1; // ComboBox seçimini temizle
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı silinirken bir hata oluştu.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kullanıcı silinirken bir hata oluştu: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına erişirken bir hata oluştu: " + ex.Message);
                    return;
                }
            }

        }

        private void YeniHesap_Load(object sender, EventArgs e)
        {

        }
    }
}
