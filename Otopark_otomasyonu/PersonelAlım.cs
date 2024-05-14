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
    public partial class PersonelAlım : Form
    {
        public PersonelAlım()
        {
            InitializeComponent();
        }

        private void geriBTN_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void hesapOlusturBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
