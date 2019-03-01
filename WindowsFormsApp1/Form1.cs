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
using System.Configuration;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        private Database database;
        private string query = null;
        private int prodID;
        private string prodName;
        Produit formProd = new Produit();
        private List<Object> listobjects = new List<object>();
        private List<Object> listofcontrols = new List<object>();
        private DataTable DT;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            database = new Database();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();

            drvProduits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            try
            {               

                listCategories.DisplayMember = "Nom_Categorie";
                listCategories.ValueMember = "ID_Categorie";
                listCategories.SelectedValue = "ID_Categorie";
                query = "SELECT [ID_Categorie] ,[Nom_Categorie] ,[Description_Categorie] FROM [Categories]";
                cmd.CommandText = query;
                DA = new SqlDataAdapter(cmd);
                DT = new DataTable();
                DA.Fill(DT);
                listCategories.DataSource = DT;
                //database.openconnection();
                // listCategories.DataSource = database.getData(query, "Categories").Tables["Categories"];
                //listCategories.SelectedIndex = -1;
                getProducts();
                //foreach (DataGridViewRow r in drvProduits.Rows)
                //{
                //    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                //    lc.Value = r.Cells[7].Value;
                //    drvProduits[7, r.Index] = lc;       

                //}
                //foreach (DataGridViewRow r in drvProduits.Rows)
                //{
                //    //DataGridViewLinkCell lc = new DataGridViewLinkCell();
                //    //lc.Value = r.Cells[9].Value;
                //    //drvProduits[9, r.Index] = lc;

                //}

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

        private void getProducts()
        {
            
            SqlCommand cmd = con.CreateCommand();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            query = " SELECT TOP(1000)[ID_Produit]" +
                              " ,c.[Nom_Categorie]" +
                              " ,[Libelle]" +
                              " ,[Emballage]" +
                              " ,[PH]" +
                              " ,[Description_Produit]" +
                              " ,[Caracteristiques]" +
                              " ,i.[Name] as 'Image'" +
                              " ,PDF.[Name] as 'Fiche technique'" +
                              " ,PDF.FileId as 'pdfID'" +
                              " ,i.FileId as 'imageID'" +
                          " FROM [Produits] as p" +
                        " join Categories as c on p.ID_Categorie = c.ID_Categorie" +
                        " join Images as i on p.img_produit = i.FileId" +
                        " left join Pdfs as PDF on p.fiche_techniques = PDF.FileId";
            // SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);
            drvProduits.DataSource = DT;
            //database.closeconnecion();
            //database.openconnection();
            //drvProduits.DataSource = database.getData(query, "Produits").Tables["Produits"];
            if (drvProduits.Rows.Count > 0)
            {
                drvProduits.Columns[9].Visible = false;
                drvProduits.Columns[10].Visible = false;
                drvProduits.Columns[0].Visible = false;
                drvProduits.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("Vous n'avez aucun produit dans la liste !");
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Produit Form_Prod = new Produit();
            formProd.Show();
            this.Hide();
        }        

        private void listCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            facoryMethod("Nom_Categorie", listCategories.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txbLibelle.Text != "")
            {
                Produit form_Produit = new Produit(txbLibelle.Text);
                form_Produit.Show();
                this.Hide();
            }
            else
            {
                //D'apres datagridView
                Produit form_Produit = new Produit(drvProduits.SelectedRows[0].Cells[0].Value.ToString());
                form_Produit.Show();
                this.Hide();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
            DialogResult result = MessageBox.Show("ete vous sur de supprimer ce produit : \"" + prodName + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                query = "DELETE FROM [dbo].[Produits] WHERE Produits.ID_Produit =@1";
                listobjects.Clear();
                listobjects.Add(prodID);
                database.openconnection();
                database.delete(query, listobjects);
                database.closeconnecion();
                MessageBox.Show("deleted with success !");
                
                string imgFile = drvProduits.CurrentRow.Cells[7].Value.ToString();
                string pdfFile = drvProduits.CurrentRow.Cells[8].Value.ToString();
                DeleteFiles(imgFile, pdfFile);
                getProducts();
            }
        }
        

        private void Button4_Click_1(object sender, EventArgs e)
        {            
            formProd.Show();
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            int pdfID=0;
            string pdfName;
            int prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            string categName = drvProduits.CurrentRow.Cells[1].Value.ToString();
            string prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
            string prodEmballage = drvProduits.CurrentRow.Cells[3].Value.ToString();
            string prodPH = drvProduits.CurrentRow.Cells[4].Value.ToString();
            string prodDesc = drvProduits.CurrentRow.Cells[5].Value.ToString();
            string prodCart = drvProduits.CurrentRow.Cells[6].Value.ToString();
            string imageName = drvProduits.CurrentRow.Cells[7].Value.ToString();            
            int imageID =int.Parse( drvProduits.CurrentRow.Cells[10].Value.ToString());

            if (drvProduits.CurrentRow.Cells[8].Value.ToString().Equals(""))
                pdfName = "DOESNTEXIST.pdf";
            else
            {
                pdfID = int.Parse(drvProduits.CurrentRow.Cells[9].Value.ToString());
                pdfName = drvProduits.CurrentRow.Cells[8].Value.ToString();
            }

            listofcontrols.Clear();
            listofcontrols.Add(prodID);
            listofcontrols.Add(categName);
            listofcontrols.Add(prodName);
            listofcontrols.Add(prodEmballage);
            listofcontrols.Add(prodPH);
            listofcontrols.Add(prodDesc);
            listofcontrols.Add(prodCart);
            listofcontrols.Add(imageID);
            listofcontrols.Add(pdfID);
            listofcontrols.Add(imageName);
            listofcontrols.Add(pdfName);            
            formProd.Show();
            formProd.UpdateProd(listofcontrols);           

        }

        private void TxbLibelle_TextChanged(object sender, EventArgs e)
        {
            facoryMethod("Libelle", txbLibelle.Text);
        }
        private void facoryMethod(string filterFd, string txtBox)
        {
            string filterField = filterFd;
            query = " SELECT TOP(1000)[ID_Produit]" +
                          " ,c.[Nom_Categorie]" +
                          " ,[Libelle]" +
                          " ,[Emballage]" +
                          " ,[PH]" +
                          " ,[Description_Produit]" +
                          " ,[Caracteristiques]" +
                          " ,i.[Name] as 'Image'" +
                          " ,PDF.[Name] 'Fiche technique'" +
                          " ,PDF.FileId as 'pdfID'" +
                          " ,i.FileId as 'imageID'" +
                      " FROM[agroV2].[dbo].[Produits] as p" +
                    " join dbo.Categories as c on p.ID_Categorie = c.ID_Categorie" +
                    " join dbo.Images as i on p.img_produit = i.FileId" +
                    " left join dbo.Pdfs as PDF on p.fiche_techniques = PDF.FileId";
            database.closeconnecion();
            database.openconnection();
            DT = dt = database.getData(query, "Produits").Tables["Produits"];
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, txtBox);
            database.closeconnecion();
            drvProduits.DataSource = dt;
        }

        private void DrvProduits_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
        }

        private void DeleteFiles(string imgFile, string pdfFile)
        {
            string cell = null;
            string fileName = null;
            // full path required
            cell = pdfFile;
            fileName = (@"..\..\Files\Pdfs\" + cell);
            if (fileName != null || fileName != string.Empty)
            {
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);                      
                }
            }
            cell = imgFile;
            fileName = (@"..\..\Files\Images\" + cell);
            if (fileName != null || fileName != string.Empty)
            {
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);                       
                }
            }
            
        }

    }
}
