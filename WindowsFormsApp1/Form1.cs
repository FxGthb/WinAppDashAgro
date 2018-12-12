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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'agroPartnersDataSet.Categorie'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.categorieTableAdapter.Fill(this.agroPartnersDataSet.Categorie);
            // TODO: cette ligne de code charge les données dans la table 'agroPartnersDataSet.Nature'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.natureTableAdapter.Fill(this.agroPartnersDataSet.Nature);
            //hello
        }
    }
}
