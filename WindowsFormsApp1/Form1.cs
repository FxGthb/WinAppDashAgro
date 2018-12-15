using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Database database;
        public Form1()
        {
            InitializeComponent();
            database = new Database();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            try
            {
                listCategories.DisplayMember = "Nom_Categorie";
                listCategories.ValueMember = "ID_Categorie";
                listCategories.SelectedValue = "ID_Categorie";
                database.openconnection();
                listCategories.DataSource = database.select("selectCat", "Categorie").Tables["Categorie"];
                drvProduits.DataSource = database.select("selectPro", "Produits").Tables["Produits"];
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                database.closeconnecion();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void drvProduits_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
