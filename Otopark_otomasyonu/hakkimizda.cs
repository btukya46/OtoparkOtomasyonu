﻿using System;
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
    public partial class hakkimizda : Form
    {
        public hakkimizda()
        {
            InitializeComponent();
        }

        private void girişEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
