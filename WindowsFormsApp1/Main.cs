﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        Produit Form_Prdt = new Produit();
        
        public Main()
        {
            InitializeComponent();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Prdt.Show();
        }
    }
}