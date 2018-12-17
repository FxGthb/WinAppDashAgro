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
                listCategories.SelectedIndex = -1;
                foreach (DataGridViewRow r in drvProduits.Rows)
                {
                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    lc.Value = r.Cells[7].Value;
                    drvProduits[7, r.Index] = lc;       

                }
                foreach (DataGridViewRow r in drvProduits.Rows)
                {
                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    lc.Value = r.Cells[9].Value;
                    drvProduits[9, r.Index] = lc;

                }

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
        private void drvProduits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //    return;
            //if (drvProduits.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            //{
            //    string link = "http://www...";
            //    if (e.ColumnIndex == 1)
            //        System.Diagnostics.Process.Start(link + dgv.Rows[e.RowIndex].Cells[4].Value as string);
            //}
            

            //[System.Runtime.InteropServices.DllImport("shell32. dll")]
            //private static extern long ShellExecute(Int32 hWnd, string lpOperation,
            //                        string lpFile, string lpParameters,
            //                            string lpDirectory, long nShowCmd);


        }
        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void drvProduits_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
