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
        byte[] binaryData;
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
            
            drvProduits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            try
            {
                

                listCategories.DisplayMember = "Nom_Categorie";
                listCategories.ValueMember = "ID_Categorie";
                listCategories.SelectedValue = "ID_Categorie";
                query = "SELECT [ID_Categorie] ,[Nom_Categorie] ,[Description_Categorie] FROM [dbo].[Categorie]";
                database.openconnection();
                listCategories.DataSource = database.getData(query, "Categorie").Tables["Categorie"];
                //listCategories.SelectedIndex = -1;
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
                    " join dbo.Categorie as c on p.ID_Categorie = c.ID_Categorie" +
                    " join dbo.Images as i on p.img_produit = i.FileId" +
                    " join dbo.Pdfs as PDF on p.fiche_techniques = PDF.FileId";
                database.closeconnecion();
                database.openconnection();
                drvProduits.DataSource = database.getData(query, "Produits").Tables["Produits"];
                drvProduits.Columns[9].Visible = false;
                drvProduits.Columns[10].Visible = false;
                drvProduits.Columns[0].Visible = false;
                drvProduits.Rows[0].Selected = true;
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
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Libelle,Categorie.Nom_Categorie,Emballage,PH,Description_Produit,Title_image,Title_pdf from Produit"+
                                " join Categorie on Produit.ID_Categorie = Categorie.ID_Categorie where Produit.Libelle Like '%" + txbLibelle.Text + "%'";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            drvProduits.DataSource = DT;
        }

        private void drvProduits_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                if(txbLibelle.Text != "")
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Select fiche_techniques from Produit where Produit.Libelle ='" + txbLibelle.Text + "'";
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if(DT.Rows.Count != 0)
                    {
                        binaryData = (byte[])DT.Rows[0][0];
                        //File.WriteAllBytes("Test.txt", binaryData);

                        using (StreamWriter sw = new StreamWriter($"{txbLibelle.Text}.pdf"))
                        {
                            BinaryWriter bw = new BinaryWriter(sw.BaseStream);
                            bw.Write(binaryData);
                        }
                        //axAcroPDF1.src = "testpdf.pdf";
                        Form_PDF_Viewer form_pdf_Viewer = new Form_PDF_Viewer(txbLibelle.Text);
                        form_pdf_Viewer.Show();
                    }
                    else
                    {
                        MessageBox.Show("Aucune fiche technique n'a ete trouvée");
                    }   

                    //PdfDocument doc = new PdfDocument();
                    //doc.LoadFromBytes(binaryData);
                    //doc.SaveToFile("File.pdf");
                }
                else
                {
                    MessageBox.Show("Please insert a Prod name");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur c'est produite lors du chargement du fichier PDF.\nPlus de details : \n"+ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Produit Form_Prod = new Produit();
            formProd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string prodName = drvProduits
            
            //    try
            //    {
            //        DialogResult result = MessageBox.Show("Do you really want to delete the product \"" + textBox1.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            query = "DELETE FROM `films`.`film` WHERE idfilm=@1";
            //            listobjects.Clear();
            //            listobjects.Add(idfilm);
            //            db.OpenConnection();
            //            db.delete(query, listobjects);
            //            db.CloseConnection();
            //            MessageBox.Show("deleted with success !");
            //            //refill the data grid view
            //            updatefilms_Load(sender, e);
            //            button_new_Click(sender, e);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Delete was not done.\n"+ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            
            
        }

        private void listCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandText = "Select Libelle,Categorie.Nom_Categorie,Emballage,PH,Description_Produit,Title_image,Title_pdf from Produit join Categorie on Produit.ID_Categorie = Categorie.ID_Categorie where Categorie.ID_Categorie ="+listCategories.SelectedValue;
            //    if (con.State == ConnectionState.Closed)
            //        con.Open();
            //    SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //    DataTable DT = new DataTable();
            //    DA.Fill(DT);
            //    drvProduits.DataSource = DT;
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
            //query = "DELETE FROM [dbo].[Produit] WHERE Produit.ID_Produit =@1";
            //listobjects.Clear();
            //listobjects.Add(prodID);
            //database.openconnection();
            //database.delete(query, listobjects);
            //database.closeconnecion();
            //MessageBox.Show("deleted with success !");
        }

        private void DrvProduits_SelectionChanged(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you really want to delete the film \"" + prodName + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (result == DialogResult.Yes)
            //{
            //prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            //prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
            //}
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {            
            formProd.Show();
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            int prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            string categName = drvProduits.CurrentRow.Cells[1].Value.ToString();
            string prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
            string prodEmballage = drvProduits.CurrentRow.Cells[3].Value.ToString();
            string prodPH = drvProduits.CurrentRow.Cells[4].Value.ToString();
            string prodDesc = drvProduits.CurrentRow.Cells[5].Value.ToString();
            string prodCart = drvProduits.CurrentRow.Cells[6].Value.ToString();
            string imageName = drvProduits.CurrentRow.Cells[7].Value.ToString();
            string pdfName = drvProduits.CurrentRow.Cells[8].Value.ToString();
            int imageID =int.Parse( drvProduits.CurrentRow.Cells[10].Value.ToString());
            int pdfID = int.Parse(drvProduits.CurrentRow.Cells[9].Value.ToString());
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
            //listofcontrols.Add(ImageArray);
            //listofcontrols.Add(prodImagaTitle);
            //foreach (var item in ImageArray)
            //{
            //    MessageBox.Show(item.ToString());
            //}
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
                    " join dbo.Categorie as c on p.ID_Categorie = c.ID_Categorie" +
                    " join dbo.Images as i on p.img_produit = i.FileId" +
                    " join dbo.Pdfs as PDF on p.fiche_techniques = PDF.FileId";
            database.closeconnecion();
            database.openconnection();
            DT = dt = database.getData(query, "films").Tables["films"];
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, txtBox);
            database.closeconnecion();
            drvProduits.DataSource = dt;
        }

        private void DrvProduits_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            prodID = int.Parse(drvProduits.CurrentRow.Cells[0].Value.ToString());
            prodName = drvProduits.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
