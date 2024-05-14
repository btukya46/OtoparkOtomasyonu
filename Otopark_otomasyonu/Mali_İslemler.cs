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
    public partial class Mali_İslemler : Form
    {
        public Mali_İslemler()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa1 = new anasayfa();
            anasayfa1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kazanc = Convert.ToInt32(textBox1.Text);
            int vergi = Convert.ToInt32(comboBox1.Text);

            int Hvergi = (kazanc * vergi / 100);
            label4.Text = Hvergi.ToString();

        }
    }
}
