using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Otopark_otomasyonu
{
    public partial class iletisim : Form
    {
        public iletisim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gönderen e-posta adresi
            string fromEmail = textBox1.Text;

            // Alıcı e-posta adresi
            string toEmail = "bat.kaya46@gmail.com";

            // E-posta konusu
            string subject = "Bize Ulaşın Formu";

            // E-posta içeriği
            string body = richTextBox1.Text;


            try
            {
                // E-posta gönderme işlemi için SMTP istemcisi oluştur
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 465; // Gmail SMTP portu
                smtpClient.Credentials = new NetworkCredential("bat.kaya46@gmail.com", "btukya789789");
                smtpClient.EnableSsl = true; // SSL/TLS şifreleme kullan

                // E-posta mesajını oluştur
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

                // E-posta gönder
                smtpClient.Send(mailMessage);

                MessageBox.Show("E-posta başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
