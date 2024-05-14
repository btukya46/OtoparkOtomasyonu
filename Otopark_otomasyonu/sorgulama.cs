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
    public partial class sorgulama : Form
    {
        public sorgulama()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home anasayfa = new home();
            anasayfa.Show();
            this.Hide();

        }
    }
}
