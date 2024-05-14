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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private TimeSpan HesaplananKalisSuresi(DateTime girisZamani)
        {
            DateTime simdi = DateTime.Now;

            TimeSpan kalisSure = simdi - girisZamani;

            return kalisSure;
        }

        private void VerileriGetir(string plakaNumarasi)
        {
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM AracKayit WHERE AracPlakasi = @PlakaNumarasi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PlakaNumarasi", plakaNumarasi);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        if (dataTable.Rows.Count == 0)
                        {
                            dataGridView2.DataSource = null;
                            dataGridView2.Rows.Clear();
                            dataGridView2.Refresh();

                            MessageBox.Show("Belirtilen plakalı araç bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridView2.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından veri alınırken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO AracKayit (AracGetirenBirim, GirisZamani, Ad, Soyad, Telefon, OdemeBilgisi, 
                    CekimNedeni, AracCinsi, AracMarkasi, AracModeli, ModelYili, AracRuhsati, AracRengi, AracPlakasi) 
                    VALUES (@AracGetirenBirim, @GirisZamani, @Ad, @Soyad, @Telefon, @OdemeBilgisi, 
                    @CekimNedeni, @AracCinsi, @AracMarkasi, @AracModeli, @ModelYili, @AracRuhsati, @AracRengi, @AracPlakasi)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {


                    try
                    {

                        cmd.Parameters.AddWithValue("@AracGetirenBirim", radioButton5.Checked ? "Kişisel" : "Trafik Şube");
                        cmd.Parameters.AddWithValue("@GirisZamani", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Ad", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Soyad", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Telefon", textBox3.Text);
                        cmd.Parameters.AddWithValue("@OdemeBilgisi", radioButton8.Checked ? "Nakit" : (radioButton9.Checked ? "Banka-Hesap Kartı" : "Trafik-TcNo"));
                        cmd.Parameters.AddWithValue("@AracCinsi", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@CekimNedeni", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@AracMarkasi", comboBox3.Text);
                        cmd.Parameters.AddWithValue("@AracModeli", textBox8.Text);
                        cmd.Parameters.AddWithValue("@ModelYili", int.Parse(textBox7.Text));
                        cmd.Parameters.AddWithValue("@AracRuhsati", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@AracRengi", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@AracPlakasi", textBox9.Text);


                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Araç kaydı başarıyla eklendi.");
                            textBox9.Clear();
                            textBox8.Clear();
                            textBox7.Clear();
                            textBox4.Clear();
                            textBox3.Clear();
                            textBox2.Clear();
                            richTextBox1.Clear();
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;
                            comboBox5.SelectedIndex = -1;

                        }
                        else
                        {
                            MessageBox.Show("Araç kaydı eklenirken bir hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanına erişirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {




        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Mali_İslemler mali_islemler = new Mali_İslemler();
            mali_islemler.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string aracPlakasi = textBox29.Text;

            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT GirisZamani, AracCinsi, AracMarkasi, AracModeli, ModelYili, AracRuhsati FROM AracKayit WHERE AracPlakasi = @AracPlakasi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@AracPlakasi", aracPlakasi);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            DateTime girisZamani = (DateTime)reader["GirisZamani"];
                            TimeSpan kalisSuresi = HesaplananKalisSuresi(girisZamani);

                            string kalisSureFormatli = string.Format("{0} gün, {1} saat, {2} dakika", kalisSuresi.Days, kalisSuresi.Hours, kalisSuresi.Minutes);

                            textBox6.Text = kalisSureFormatli;
                            textBox5.Text = reader["AracCinsi"].ToString();
                            textBox1.Text = reader["AracMarkasi"].ToString();
                            textBox31.Text = reader["AracModeli"].ToString();
                            textBox30.Text = reader["ModelYili"].ToString();
                            textBox23.Text = reader["AracRuhsati"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen araç plakasıyla eşleşen veri bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından veri alınırken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string plakaNumarasi = textBox32.Text;
            VerileriGetir(plakaNumarasi);
        }

        private void AracCikisYap(object sender, EventArgs e)
        {
            // Arac plakasını al
            string aracPlakasi = textBox29.Text;

            // Veritabanı bağlantı dizesi
            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            // Arac kaydını almak için sorgu
            string selectQuery = "SELECT * FROM AracKayit WHERE AracPlakasi = @AracPlakasi";

            // Arac kaydını silmek için sorgu
            string deleteQuery = "DELETE FROM AracKayit WHERE AracPlakasi = @AracPlakasi";

            // Arac çıkışını kaydetmek için sorgu
            string insertQuery = "INSERT INTO CikisYapilanAraclar (AracPlakasi, CikisTarihiSaat, KaldigiSure, Ucret, KisiAdi, Soyadi, Telefon, OdemeYapildiMi, OdemeTuru) " +
                                 "VALUES (@AracPlakasi, @CikisTarihiSaat, @KaldigiSure, @Ucret, @KisiAdi, @Soyadi, @Telefon, @OdemeYapildiMi, @OdemeTuru)";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Arac kaydını sorgula
                using (SqlCommand cmdSelect = new SqlCommand(selectQuery, conn))
                {
                    cmdSelect.Parameters.AddWithValue("@AracPlakasi", aracPlakasi);

                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Arac kaydı bulunduğunda işlemleri gerçekleştir
                            if (reader.Read())
                            {
                                // Gerekli bilgileri al
                                string kisiAdi = textBox27.Text;
                                string soyadi = textBox28.Text;
                                string telefon = textBox26.Text;
                                bool odemeYapildiMi = checkBox1.Checked;
                                string odemeTuru = "";

                                if (radioButton18.Checked)
                                {
                                    odemeTuru = "Nakit";
                                }
                                else if (radioButton16.Checked)
                                {
                                    odemeTuru = "Banka - Hesap Kartı";
                                }
                                else if (radioButton15.Checked)
                                {
                                    odemeTuru = "Trafik - Tc No";
                                }

                                // Arac çıkışı için gerekli bilgileri al
                                DateTime cikisTarihiSaat = DateTime.Now;
                                DateTime girisTarihiSaat = reader.GetDateTime(reader.GetOrdinal("GirisZamani"));
                                TimeSpan kaldigiSure = cikisTarihiSaat - girisTarihiSaat;
                                int kaldigiDakika = (int)kaldigiSure.TotalMinutes;
                                decimal ucret = kaldigiDakika * 1; // Ucreti burada belirledim, siz istediğiniz gibi güncelleyebilirsiniz

                                // Arac çıkışını kaydet
                                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                                {
                                    cmdInsert.Parameters.AddWithValue("@AracPlakasi", aracPlakasi);
                                    cmdInsert.Parameters.AddWithValue("@CikisTarihiSaat", cikisTarihiSaat);
                                    cmdInsert.Parameters.AddWithValue("@KaldigiSure", kaldigiDakika);
                                    cmdInsert.Parameters.AddWithValue("@Ucret", ucret);
                                    cmdInsert.Parameters.AddWithValue("@KisiAdi", kisiAdi);
                                    cmdInsert.Parameters.AddWithValue("@Soyadi", soyadi);
                                    cmdInsert.Parameters.AddWithValue("@Telefon", telefon);
                                    cmdInsert.Parameters.AddWithValue("@OdemeYapildiMi", odemeYapildiMi);
                                    cmdInsert.Parameters.AddWithValue("@OdemeTuru", odemeTuru);
                                    cmdInsert.ExecuteNonQuery();
                                }

                                // Arac kaydını sil
                                using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn))
                                {
                                    cmdDelete.Parameters.AddWithValue("@AracPlakasi", aracPlakasi);
                                    cmdDelete.ExecuteNonQuery();
                                }

                                MessageBox.Show("Aracın çıkışı yapıldı. Ücret: " + ucret.ToString("C2"));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen plakalı araç bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            
            DolulukOraniPastaGrafiginiGoster();
        }

        private int MevcutAracSayisiniGetir()
        {
            int mevcutAracSayisi = 0;

            string connStr = "Data Source=BATUHAN\\SQLEXPRESS;Initial Catalog=otopark;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM AracKayit";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        mevcutAracSayisi = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            label7.Text = "Toplam Alan: 254";
            label13.Text = "Dolu Alan: " + mevcutAracSayisi.ToString();
            label49.Text = "Boş Alan: " + (254 - mevcutAracSayisi).ToString();

            return mevcutAracSayisi;
        }

        private void HesaplaVeGoster()
        {
            // Toplam park yeri kapasitesini kullanıcıdan al
            int toplamParkYeriKapasitesi = 154;

            // Mevcut araç sayısını veritabanından al
            int mevcutAracSayisi = MevcutAracSayisiniGetir();

            // Doluluk oranını hesapla
            double dolulukOrani = DolulukOraniHesapla(mevcutAracSayisi, toplamParkYeriKapasitesi);

            // Doluluk oranını ekranda göster
            label7.Text = $"Doluluk Oranı: {dolulukOrani}%";
        }

        private double DolulukOraniHesapla(int mevcutAracSayisi, int toplamParkYeriKapasitesi)
        {
            // Doluluk oranını hesapla
            double dolulukOrani = (double)mevcutAracSayisi / toplamParkYeriKapasitesi * 100;

            return dolulukOrani;
        }

        private void DolulukOraniPastaGrafiginiGoster()
        {
            // Chart bileşenini temizle
            chartDolulukOrani.Series.Clear();

            // Yeni bir seri oluştur (pasta grafiği için)
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Doluluk Oranı",
                IsVisibleInLegend = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };

            // Mevcut araç sayısını veritabanından al
            int mevcutAracSayisi = MevcutAracSayisiniGetir();

            // Toplam park yeri kapasitesi
            int toplamParkYeriKapasitesi = 154;

            // Doluluk oranını hesapla
            double dolulukOrani = DolulukOraniHesapla(mevcutAracSayisi, toplamParkYeriKapasitesi);

            // Boşluk oranını hesapla (100% - dolulukOrani)
            double boslukOrani = 100 - dolulukOrani;

            // Seriye verileri ekle
            series.Points.AddXY("Dolu", dolulukOrani);
            series.Points.AddXY("Boş", boslukOrani);

            // Seriyi grafiğe ekle
            chartDolulukOrani.Series.Add(series);
        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kazanc = Convert.ToInt32(textBox10.Text);
            int vergi = Convert.ToInt32(comboBox4.Text);

            int Hvergi = (kazanc * vergi / 100);
            label26.Text = Hvergi.ToString();
        }
    }
}
