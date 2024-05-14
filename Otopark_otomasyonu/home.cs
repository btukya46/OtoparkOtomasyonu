using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_otomasyonu
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfa ekle = new anasayfa();
            ekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sorgulama sorgulamaE = new sorgulama();
            sorgulamaE.Show();
            this.Hide();
        }

        private void DolulukBTN_Click(object sender, EventArgs e)
        {
            otopark_doluluk_oranı otopark = new otopark_doluluk_oranı();
            otopark.Show();
            this.Hide();
        }

        private void yetkiliGiris_BTN_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
