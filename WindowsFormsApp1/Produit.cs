using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Produit : Form
    {
        
        #region variables
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand comm;
        SqlDataReader sqlDtReader;
        SqlParameter imageId;
        SqlDataAdapter sqlDtAdapter;
        DataSet dtSet;
        BindingSource bindingSource;
        int ImageID = 0;
        int pdfID = 0;
        String strFilePath = "";
        String pdfstrFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        Byte[] pdfByteArray;
        byte[] fileData;

        List<string> ListNature = new List<string>();
        List<int> List_ID_Nature = new List<int>();

        #endregion

        public Produit()
        {
            InitializeComponent();
            dtSet = new DataSet();
            bindingSource = new BindingSource();
        }

        private void buttonAjouterProduit_Click(object sender, EventArgs e)
        {
            try
            {
                #region add product image to image table
                if (txtTitle.Text.Trim() != "")
                {

                    if (strFilePath == "")
                    {
                        if (ImageByteArray.Length != 0)
                            ImageByteArray = new byte[] { };
                    }
                    else
                    {
                        Image temp = new Bitmap(strFilePath);

                        MemoryStream strm = new MemoryStream();

                        temp
                            .Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);

                        ImageByteArray = strm
                                            .ToArray();


                    }
                    if (conn.State == ConnectionState.Closed)
                        conn
                            .Open();

                    SqlCommand sqlCmd = new
                                            SqlCommand("ImageAddOrEdit", conn)
                    { CommandType = CommandType.StoredProcedure };



                    sqlCmd
                        .Parameters
                            .AddWithValue("@ImageID", ImageID);

                    sqlCmd
                        .Parameters
                            .AddWithValue("@Title", txtTitle.Text.Trim());

                    sqlCmd
                        .Parameters
                            .AddWithValue("@Image", ImageByteArray);

                    sqlCmd
                        .ExecuteNonQuery();

                    conn
                        .Close();

                    MessageBox
                        .Show("Image saved successfuly");
                }
                else
                {
                    MessageBox
                        .Show("Please enter image title");
                }
                #endregion

                #region add product documentation : PDF file to pdfFils table
                if (txtPDFTitle.Text.Trim() != "")
                {

                    if (pdfstrFilePath == "")
                    {
                        if (pdfByteArray.Length != 0)
                            pdfByteArray = new byte[] { };
                    }
                    else
                    {
                        fileData = File.ReadAllBytes(pdfstrFilePath);
                    }
                    if (conn.State == ConnectionState.Closed)
                        conn
                            .Open();

                    SqlCommand sqlCmd = new
                                            SqlCommand("pdfAddOrEdit", conn)
                    { CommandType = CommandType.StoredProcedure };

                    sqlCmd
                        .Parameters
                            .AddWithValue("@pdfID", pdfID);

                    sqlCmd
                        .Parameters
                            .AddWithValue("@Title", txtPDFTitle.Text.Trim());

                    sqlCmd
                        .Parameters
                            .AddWithValue("@pdfFile", fileData);

                    sqlCmd
                        .ExecuteNonQuery();

                    conn
                        .Close();

                    MessageBox
                        .Show("Pdf file saved successfuly");
                }
                else
                {
                    MessageBox
                        .Show("Please enter pdf title");
                }
                #endregion

                #region retrieve imageId
                SqlCommand sqlcomm = conn.CreateCommand();

                sqlcomm.CommandText = "  SELECT TOP 1 ImageID FROM Image ORDER BY ImageID DESC";

                conn.Open();
                sqlDtReader = sqlcomm.ExecuteReader();
                sqlDtReader.Read();
                int imageId = sqlDtReader.GetInt32(0);
                MessageBox.Show(imageId.ToString());
                conn.Close();
                #endregion
                sqlcomm = conn.CreateCommand();

                sqlcomm.CommandText = "  SELECT TOP 1 pdfID FROM pdf_files ORDER BY pdfID DESC";

                conn.Open();
                sqlDtReader = sqlcomm.ExecuteReader();
                sqlDtReader.Read();
                int pdfId = sqlDtReader.GetInt32(0);
                MessageBox.Show(imageId.ToString());
                conn.Close();
                #region retrieve pdfFileID

                #endregion

                #region add new product proccess
                SqlCommand comm = new
                                      SqlCommand("AddProduct", conn)
                { CommandType = CommandType.StoredProcedure };

                MessageBox.Show(imageId.ToString());

                comm
                       .Parameters
                       .AddWithValue("@ID_Categorie", listCategories.SelectedValue);
                comm
                    .Parameters
                    .AddWithValue("@Libelle", libelleProduit.Text);
                comm
                    .Parameters
                    .AddWithValue("@Emballage", emballageProduit.Text);
                comm
                    .Parameters
                    .AddWithValue("@PH", phProduit.Text);

                //comm
                //    .Parameters
                //    .AddWithValue("@@Fiche_Techniques", null);

                comm
                    .Parameters
                    .AddWithValue("@Description_Produit", descriptionProduit.Text);
                comm
                    .Parameters
                    .AddWithValue("@Caracteristiques", carateristiqueProduit.Text);

                comm
                    .Parameters
                    .AddWithValue("@id_image_produit", imageId);

                comm
                    .Parameters
                    .AddWithValue("@id_pdf_produit", pdfId);

                //comm
                //    .Parameters
                //    .AddWithValue("@image_id", 1);

                conn.Open();

                comm
                    .ExecuteNonQuery();

                MessageBox
                   .Show("Produit ajouter avec succes !");

                conn
                    .Close();
                #endregion

                #region add natures to product
                sqlcomm = conn.CreateCommand();

                sqlcomm.CommandText = "select IDENT_CURRENT('Produit')";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                sqlcomm.ExecuteNonQuery();
                sqlDtAdapter = new SqlDataAdapter(sqlcomm);
                DataTable DT = new DataTable();
                sqlDtAdapter.Fill(DT);
                int produitId = int.Parse(DT.Rows[0][0].ToString());
                
                MessageBox.Show(produitId.ToString());

                foreach(var item in ListNature)
                {
                    sqlcomm.CommandText = "select ID_Nature from Nature where Description_Nature  ='"+item.ToString()+"'";
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    sqlcomm.ExecuteNonQuery();
                    sqlDtAdapter = new SqlDataAdapter(sqlcomm);
                    DT = new DataTable();
                    sqlDtAdapter.Fill(DT);
                    if(DT.Rows.Count > 0)
                    {
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            List_ID_Nature.Add((int)DT.Rows[i][0]);
                        }
                    }
                }
                foreach(var id in List_ID_Nature)
                {
                    sqlcomm.CommandText = $"Insert into NatureProduit Values({id},{produitId})";
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    sqlcomm.ExecuteNonQuery();
                    MessageBox.Show("Inserted in nature Produit");
                }
                

                #endregion

            }
            catch (Exception exception)
            {
                MessageBox
                    .Show( exception.ToString() );
            }
            finally
            {
                conn
                    .Close();
            }            
        }

        #region formLOAD
        private void Produit_Load(object sender, EventArgs e)
        {
            //Main Main = new Main();
            //this.MdiParent=Main;
            comboBox_Statut.SelectedIndex = 0;

            try
            {
                String query
                        = "SELECT ID_Categorie , Nom_Categorie FROM Categorie";

                sqlDtAdapter = new SqlDataAdapter(query , conn);

                sqlDtAdapter
                    .Fill(dtSet, "Categorie");

                bindingSource
                    .DataSource =
                            dtSet
                                .Tables["Categorie"];

                listCategories
                    .DisplayMember = "Nom_Categorie";

                listCategories
                    .ValueMember = "ID_Categorie";

                listCategories
                    .SelectedValue = "ID_Categorie";

                listCategories
                    .DataSource =
                            dtSet
                                .Tables["Categorie"];

                query =
                        "SELECT ID_Nature, Description_Nature FROM Nature";

                sqlDtAdapter = new SqlDataAdapter(query, conn);

                sqlDtAdapter
                    .Fill(dtSet, "Nature");

                bindingSource
                    .DataSource =
                               dtSet
                                    .Tables["Nature"];

               
                for (int i = 0; i < dtSet.Tables["Nature"].Rows.Count; i++)
                {
                    chelistbox_nature.Items.Add(dtSet.Tables["Nature"].Rows[i][1]);
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.ToString());
            }
            finally
            {
                //conn.Close();
            }
        }
        #endregion

        #region button browse image clickEvent()
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pbxImage.Image = new Bitmap(strFilePath);
                if (txtTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    txtTitle.Text = System.IO.Path.GetFileName(strFilePath);
            }
        }
        #endregion

        #region browse pdf clickEvent()
        private void btnBrowsePdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pdf Files|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pdfstrFilePath = ofd.FileName;
                //pbxImage.Image = new Bitmap(strFilePath);
                if (txtPDFTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    txtPDFTitle.Text = System.IO.Path.GetFileName(pdfstrFilePath);
            }

        }
        #endregion

        private void chelistbox_nature_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
                ListNature.Add(chelistbox_nature.Items[e.Index].ToString());
            else
            {
                if (e.Index != 0)
                    ListNature.RemoveAt(e.Index);
                else
                    ListNature.Clear();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListNature.Count > 0)
            {
                foreach (var item in ListNature)
                {
                    MessageBox.Show(item);
                }
            }
            else
                MessageBox.Show("Aucun element n'a ete selectionne");
        }

        
    }
}
