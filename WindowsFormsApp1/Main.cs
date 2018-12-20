using System;
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
        
        
        public Main()
        {
            InitializeComponent();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            produit.MdiParent = this;
            produit.Show();
        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void listeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }
    }
}
