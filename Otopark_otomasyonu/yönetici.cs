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
    public partial class yönetici : Form
    {
        public yönetici()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yetkili_giris yetkiligiris = new yetkili_giris();
            yetkiligiris.Show();
            this.Hide();

        }
    }
}
