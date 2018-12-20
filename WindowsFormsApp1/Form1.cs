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
            cmd.CommandText = "Select Libelle,Categorie.Nom_Categorie,Emballage,PH,Description_Produit,Title_image,Title_pdf from Produit join Categorie on Produit.ID_Categorie = Categorie.ID_Categorie where Produit.Libelle Like '%" + txbLibelle.Text + "%'";
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
            Produit Form_Prod = new Produit();
            Form_Prod.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in drvProduits.SelectedRows)
            {
                try
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "delete Produit where Libelle ='" + item.Cells[0].Value.ToString() + "'";
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted !!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete was not done.\n"+ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            
        }

        private void listCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Libelle,Categorie.Nom_Categorie,Emballage,PH,Description_Produit,Title_image,Title_pdf from Produit join Categorie on Produit.ID_Categorie = Categorie.ID_Categorie where Categorie.ID_Categorie ="+listCategories.SelectedValue;
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            drvProduits.DataSource = DT;
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
    }
}
