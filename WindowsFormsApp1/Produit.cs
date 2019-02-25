using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Produit : Form
    {
        
        #region variables
       
        int idPro = 0;
        DataTable DT = new DataTable();
        private List<Object> list = new List<object>();
        private List<String> listparam = new List<String>();
        string fileName;
        private string fileSavePath;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString); 
        private Database database;
        string ProdName;
        private string query;
        private string pdffileName;
        private string pdffileSavePath;
        private int imageID;
        private int pdfID;
        private string imageName;
        private string pdfName;
        private bool cantChooseImgFile = false;
        private bool imgFileIsChoosen;
        private bool pdfFileIsChoosen;
        private bool cantChoosePdfFile;
        private bool commingFromUpdateBtn;

        #endregion

        public Produit()
        {
            InitializeComponent();
            database = new Database();
            
        }

        public Produit(string Prod)
        {
            InitializeComponent();
            ProdName = Prod;
        }
       
        private void Produit_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            imgFileIsChoosen = false;
            pdfFileIsChoosen = false;
            buttonUpdateProduit.Enabled = false;
            btn_ADD.Enabled = true;
            cantChooseImgFile = false;
            cantChoosePdfFile = false;


            //if (ProdName != null)
            //{
            //    SqlCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = "Select * from Produits where Libelle ='"+ProdName+"'";
            //    if (conn.State == ConnectionState.Closed)
            //        conn.Open();
            //    SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //    DataTable DT = new DataTable();
            //    DA.Fill(DT);

            //}
            //else
            //{
            //comboBox_Statut.SelectedIndex = 0;
            try
            {
                listCategories.DisplayMember = "Nom_Categorie";
            listCategories.ValueMember = "ID_Categorie";
            listCategories.SelectedValue = "ID_Categorie";
            query = "SELECT [ID_Categorie] ,[Nom_Categorie] ,[Description_Categorie] ,[Img_PATH] FROM [Categories]";
            database.openconnection();
            listCategories.DataSource = database.getData(query, "Tab_Categories").Tables["Tab_Categories"];

                //SqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = query;
                //SqlDataAdapter TestDA = new SqlDataAdapter(cmd);
                //DataTable DT = new DataTable();
                //TestDA.Fill(DT);
                //listCategories.DataSource = DT;
                //listCategories.SelectedIndex = -1;
              }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                database.closeconnecion();
            }
            // }
            //Set AutoGenerateColumns False.
            dataGridView1.AutoGenerateColumns = false;

            //Set Columns Count.
            dataGridView1.ColumnCount = 1;

            //Add Columns.

           // dataGridView1.Columns[0].Name = "Id";
            //dataGridView1.Columns[0].HeaderText = "Image Id";
            //dataGridView1.Columns[0].DataPropertyName = "FileId";

            dataGridView1.Columns[0].HeaderText = "Nom";
            dataGridView1.Columns[0].Name = "Nom";
            dataGridView1.Columns[0].DataPropertyName = "Nom";

            //Add a Image Column to the DataGridView at the third position.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";
            imageColumn.DataPropertyName = "Data";
            imageColumn.HeaderText = "Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns.Insert(1, imageColumn);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.Columns[1].Width = 100;

            //Bind DataGridView.
            //this.BindDataGridView();

        }


        public void UpdateProd(List<Object> listofcontrols)
        {
            buttonUpdateProduit.Enabled = true;
            btn_ADD.Enabled = false;
            commingFromUpdateBtn = true;
            int index;
            idPro = int.Parse(listofcontrols[0].ToString());
            libelleProduit.Text = listofcontrols[2].ToString();
            emballageProduit.Text = listofcontrols[3].ToString();
            phProduit.Text = listofcontrols[4].ToString();
            descriptionProduit.Text = listofcontrols[5].ToString();
            imageID = int.Parse(listofcontrols[7].ToString());
            pdfID = int.Parse(listofcontrols[8].ToString());
            imageName = listofcontrols[9].ToString();
            pdfName = listofcontrols[10].ToString();
            carateristiqueProduit.Text = listofcontrols[6].ToString();
            index = listCategories.FindString(listofcontrols[1].ToString());
            listCategories.SelectedIndex = index;
            //get image 
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT i.FileId, i.Name, i.Path FROM [agroV2].[dbo].[Images] as i" +
                       " join dbo.Produits as p on i.FileId = p.img_produit where p.ID_Produit = '" + idPro + "'", conn))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Add a new Byte[] Column.
                dt.Columns.Add("Data", Type.GetType("System.Byte[]"));

                //Convert all Images to Byte[] and copy to DataTable.
                foreach (DataRow row in dt.Rows)
                {
                    row["Data"] = File.ReadAllBytes(row["Path"].ToString());
                }

                dataGridView1.DataSource = dt;
                dataGridView1.Rows[0].Cells[0].Value = dt.Rows[0][1];
            }

            //get pdf
            if (pdfID != 0)
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT pdf.FileId, pdf.Name, pdf.Path FROM [agroV2].[dbo].[Pdfs] as pdf" +
                       " join dbo.Produits as p on pdf.FileId = p.fiche_techniques where p.ID_Produit = '" + idPro + "'", conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Add a new Byte[] Column.
                    dt.Columns.Add("Data", Type.GetType("System.Byte[]"));

                    //Convert all Images to Byte[] and copy to DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Data"] = File.ReadAllBytes(row["Path"].ToString());
                    }

                    axAcroPDF1.LoadFile(dt.Rows[0][2].ToString());
                    //dataGridView1.Rows[0].Cells[0].Value = dt.Rows[0][1];
                }
            }          


        }

        private void buttonAjouterProduit_Click(object sender, EventArgs e)
        {
            int imgID = 0;
            int pdfID = 0;
            bool noPDF = true;
            try
            {
                //Int32 id_cate = (int)listCategories.SelectedValue;
                //String libl = libelleProduit.Text.Trim();
                //String embal = emballageProduit.Text.Trim();
                //String ph = phProduit.Text.Trim();
                //String desc = descriptionProduit.Text.Trim();
                //String carac = carateristiqueProduit.Text.Trim();
                //String title_image = txtImgTitle.Text.Trim();
                //String title_pdf = txtPDFTitle.Text.Trim();

                //insert image produit
                if (DT.Rows.Count > 0)
                {
                    query = "INSERT INTO [dbo].[Images] ([Name],[Path]) VALUES (@1,@2)";
                    list.Clear();
                    list.Add(Path.GetFileName(fileName));
                    list.Add(fileSavePath);
                    database.openconnection();
                    database.insert(query, list);
                    database.closeconnecion();
                    MessageBox.Show("image Added !!");

                    //get image id
                    query = "SELECT MAX(FileId) as 'imgID' FROM Images";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        conn.Open();
                        imgID = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }
                else MessageBox.Show("Veuillez choisir une image !");

                if (!axAcroPDF1.src.Equals("DOESNTEXIST.pdf"))
                {
                    query = "INSERT INTO [dbo].[Pdfs] ([Name],[Path]) VALUES (@1,@2)";
                    list.Clear();
                    list.Add(Path.GetFileName(pdffileName));
                    list.Add(pdffileSavePath);
                    database.openconnection();
                    database.insert(query, list);
                    MessageBox.Show("pdf Added !!");
                    database.closeconnecion();
                    noPDF = false;
                    //get pdf id
                    query = "SELECT MAX(FileId) as 'pdfID' FROM Pdfs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        pdfID = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }

                if (imgID != 0)
                {
                    if (noPDF)
                    {
                        query = "INSERT INTO[dbo].[Produits]" +
                          " ([ID_Categorie]" +
                          " ,[Libelle]" +
                          " ,[Emballage]" +
                          " ,[PH]" +
                          " ,[Description_Produit]" +
                          " ,[Caracteristiques]" +
                          " ,[img_produit]" +
                          " ,[fiche_techniques])" +
                          " VALUES(@1,@2,@3,@4,@5,@6,@7,null)";
                        Int32 id_cate = (int)listCategories.SelectedValue;
                        String libl = libelleProduit.Text.Trim();
                        String embal = emballageProduit.Text.Trim();
                        String ph = phProduit.Text.Trim();
                        String desc = descriptionProduit.Text.Trim();
                        String carac = carateristiqueProduit.Text.Trim();
                        list.Clear();
                        list.Add(id_cate);
                        list.Add(libl);
                        list.Add(embal);
                        list.Add(ph);
                        list.Add(desc);
                        list.Add(carac);
                        list.Add(imgID);
                    }
                    else
                    {
                        query = "INSERT INTO[dbo].[Produits]" +
                           " ([ID_Categorie]" +
                           " ,[Libelle]" +
                           " ,[Emballage]" +
                           " ,[PH]" +
                           " ,[Description_Produit]" +
                           " ,[Caracteristiques]" +
                           " ,[img_produit]" +
                           " ,[fiche_techniques])" +
                           " VALUES(@1,@2,@3,@4,@5,@6,@7,@8)";
                        Int32 id_cate = (int)listCategories.SelectedValue;
                        String libl = libelleProduit.Text.Trim();
                        String embal = emballageProduit.Text.Trim();
                        String ph = phProduit.Text.Trim();
                        String desc = descriptionProduit.Text.Trim();
                        String carac = carateristiqueProduit.Text.Trim();
                        list.Clear();
                        list.Add(id_cate);
                        list.Add(libl);
                        list.Add(embal);
                        list.Add(ph);
                        list.Add(desc);
                        list.Add(carac);
                        list.Add(imgID);
                        list.Add(pdfID);
                    } 
                    database.openconnection();
                    database.insert(query, list);
                    MessageBox.Show("product Added !!");
                    database.closeconnecion();
                    //DT.Clear();
                    axAcroPDF1.LoadFile("DOESNTEXIST.pdf");
                    axAcroPDF1.src = null;
                    listCategories.SelectedIndex = -1;
                    void ClearTextBoxes(Control parent)
                    {
                        foreach (Control child in parent.Controls)
                        {
                            TextBox textBox = child as TextBox;
                            if (textBox == null)
                                ClearTextBoxes(child);
                            else
                                textBox.Text = string.Empty;
                        }
                    }
                    ClearTextBoxes(this);
                }

            }
            catch (SqlException exception)
            {
                MessageBox.Show("On a pas pu ajouter le produit.Erreur details :\n" + exception.ToString(), "Echec d'insertion", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeconnecion();
                list.Clear();
                listparam.Clear();
                //DT.Clear();
                //dataGridView1.DataSource = DT;
                cantChooseImgFile = false;
                cantChoosePdfFile = false;
                if (dataGridView1.Rows.Count > 0)
                {
                    Button2_Click(sender, e);
                }
                
            }
            #region add new product proccess

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ButtonUpdateProduit_Click(object sender, EventArgs e)
        {
            bool imgEXIST = false;
            bool pdfEXIST = false;
            if (axAcroPDF1.src.Equals("DOESNTEXIST.pdf"))
            {
                MessageBox.Show("La fiche technique est obligatoire !");
                //pdfEXIST = false;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("L'image est obligatoire !");
                //imgEXIST = false;
            }

            if (imgFileIsChoosen)
            {
                //update image
                DeleteFiles(imageName, false);
                query = "UPDATE [dbo].[Images] SET [Name] = '" + Path.GetFileName(fileName) + "',[Path] = '" + fileSavePath + "' WHERE Images.FileId = @1 ";
                list.Clear();
                list.Add(imageID);
                database.openconnection();
                database.insert(query, list);
                database.closeconnecion();
                MessageBox.Show("image updated !");
                imgEXIST = true;
                imgFileIsChoosen = false;
            }

            if (pdfFileIsChoosen)
            {
               //noPDF
                if (pdfID !=0 )
                {
                    //update pdf
                    DeleteFiles(pdfName, true);
                    query = "UPDATE [dbo].[Pdfs] SET [Name] = '" + Path.GetFileName(pdffileName) + "',[Path] = '" + pdffileSavePath + "' WHERE Pdfs.FileId = @1 ";
                    list.Clear();
                    list.Add(pdfID);
                    database.openconnection();
                    database.insert(query, list);
                    database.closeconnecion();
                    MessageBox.Show("pdf updated !");
                    pdfEXIST = true;
                    pdfFileIsChoosen = false;
                }
                else
                {
                    //insert pdf
                    query = "INSERT INTO [dbo].[Pdfs] ([Name],[Path]) VALUES (@1,@2)";
                    list.Clear();
                    list.Add(Path.GetFileName(pdffileName));
                    list.Add(pdffileSavePath);
                    database.openconnection();
                    database.insert(query, list);
                    MessageBox.Show("pdf Added !!");
                    database.closeconnecion();
                    //noPDF = false;

                    //get pdf id
                    query = "SELECT MAX(FileId) as 'pdfID' FROM Pdfs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        conn.Open();
                        pdfID = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                    query = " UPDATE [dbo].[Produits] SET fiche_techniques = '"+pdfID+"' WHERE Produits.ID_Produit = @1";
                    list.Clear();
                    list.Add(idPro);
                    database.openconnection();
                    database.update(query, list);
                    database.closeconnecion();
                }
               
            }            
            
            // update product
            //if (imgEXIST || pdfEXIST)
            //{
                Int32 id_cate = (int)listCategories.SelectedValue;
                String libl = libelleProduit.Text.Trim();
                String embal = emballageProduit.Text.Trim();
                String ph = phProduit.Text.Trim();
                String desc = descriptionProduit.Text.Trim();
                String carac = carateristiqueProduit.Text.Trim();
                query = "UPDATE [dbo].[Produits]" +
                        " SET [ID_Categorie] ='" + id_cate + "' ,[Libelle] ='" + libl + "' ,[Emballage] = '" + embal + "',[PH] ='" + ph + "' ,[Description_Produit] ='" + desc + "'" +
                        " ,[Caracteristiques] = '" + carac + "'" +
                        " WHERE Produits.ID_Produit = @1";
                list.Clear();
                list.Add(idPro);
                database.openconnection();
                database.update(query, list);
                database.closeconnecion();
                MessageBox.Show("product updated !");
            //}
            //else
            //{
            //    MessageBox.Show("Veuillez choisir l'image et la fiche technique SVP!");
            //}

        }        

        private void DeleteFiles(string file, bool isPDF)
        {
            string cell = file;
            string fileName = null;
            // full path required
            if (isPDF)
            {
                fileName = (@"..\..\Files\Pdfs\" + cell);
                if (fileName != null || fileName != string.Empty)
                {
                    if ((System.IO.File.Exists(fileName)))
                    {
                        System.IO.File.Delete(fileName);
                        axAcroPDF1.LoadFile("DOESNTEXIST.pdf");
                        axAcroPDF1.src = null;
                        cantChoosePdfFile = false;
                    }
                }
            }
            else
            {
                fileName = (@"..\..\Files\Images\" + cell);
                if (fileName != null || fileName != string.Empty)
                {
                    if ((System.IO.File.Exists(fileName)))
                    {
                        System.IO.File.Delete(fileName);
                        //DT.Clear();
                        DT.Dispose();
                        ///DT = null;
                        dataGridView1.DataSource = DT;
                        cantChooseImgFile = false;
                    }

                }
            }
            
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            if (!cantChooseImgFile)
            {
                
                //DT.Rows.Add(new object[] { "Ravi", 500 });

                //string saveDirectory = @"C:\Users\DELL LATITUDE E5480\Desktop\DataGridView_Image_Path_Database\SavedImages\";
                //string saveDirectory = System.IO.Path.GetDirectoryName("Files");
                string saveDirectory = @"..\..\Files\Images\";
                //string documents = Directory.GetDirectories("../..Files");
                //string[] files = File.ReadAllLines(path);
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (!Directory.Exists(saveDirectory))
                        {
                            Directory.CreateDirectory(saveDirectory);
                        }

                        fileName = Path.GetFileName(openFileDialog1.FileName);
                        fileSavePath = Path.Combine(saveDirectory, fileName);
                        File.Copy(openFileDialog1.FileName, fileSavePath, true);
                        DT.Clear();
                        dataGridView1.DataSource = DT;
                        DT.Columns.Add("Nom");
                        DT.Columns.Add("Image");
                        DT.Columns.Add("Data", Type.GetType("System.Byte[]"));
                        DT.Rows.Add(new object[] { Path.GetFileName(fileName), fileSavePath });
                        //string constr = "Data Source=.;Initial Catalog=master;Integrated Security=True";
                        //using (SqlConnection conn = new SqlConnection(constr))
                        //{
                        //    string sql = "INSERT INTO Files VALUES(@Name, @Path)";
                        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        //    {
                        //        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(fileName));
                        //        cmd.Parameters.AddWithValue("@Path", fileSavePath);
                        //        conn.Open();
                        //        cmd.ExecuteNonQuery();
                        //        conn.Close();
                        //    }
                        //}
                        imgFileIsChoosen = true;
                        

                        //Convert all Images to Byte[] and copy to DataTable.
                        foreach (DataRow row in DT.Rows)
                        {
                            row["Data"] = File.ReadAllBytes(row["Image"].ToString());
                        }
                        dataGridView1.DataSource = DT;
                        cantChooseImgFile = true;
                        button2.Enabled = true;
                        // this.BindDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas choisi une image");
                    }
                }
            }
            else if (commingFromUpdateBtn)
            {
                //goto isCommingFromUpdate;
                MessageBox.Show("Haahahahahah exception");
            }
            else
            {
                MessageBox.Show("Vous avez déja choisis une image, voulliez supprimer l'image existante");
            }
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string cell;
            // storing value from cell
            if (DT.Rows.Count>0)
            {
                cell = dataGridView1.Rows[0].Cells[0].Value.ToString();

                // full path required
                string fileName = (@"..\..\Files\Images\" + cell);
                if (fileName != null || fileName != string.Empty)
                {
                    if ((System.IO.File.Exists(fileName)))
                    {
                        System.IO.File.Delete(fileName);
                    }

                }

            }

            cell = fileName;
            fileName = (@"..\..\Files\Pdfs\" + cell);
            if (fileName != null || fileName != string.Empty)
            {
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);
                }

            }
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            if (!cantChoosePdfFile)
            {
                
                //DT.Clear();
                //DT.Columns.Add("Nom");
                //DT.Columns.Add("Image");
                //DT.Rows.Add(new object[] { "Ravi", 500 });

                //string saveDirectory = @"C:\Users\DELL LATITUDE E5480\Desktop\DataGridView_Image_Path_Database\SavedImages\";
                //string saveDirectory = System.IO.Path.GetDirectoryName("Files");
                string saveDirectory = @"..\..\Files\Pdfs\";
                //string documents = Directory.GetDirectories("../..Files");
                //string[] files = File.ReadAllLines(path);
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.DefaultExt = ".pdf";
                    openFileDialog1.Filter = "Pdf Files|*.pdf";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (!Directory.Exists(saveDirectory))
                        {
                            Directory.CreateDirectory(saveDirectory);
                        }

                        pdffileName = Path.GetFileName(openFileDialog1.FileName);
                        pdffileSavePath = Path.Combine(saveDirectory, pdffileName);
                        File.Copy(openFileDialog1.FileName, pdffileSavePath, true);

                        axAcroPDF1.src = openFileDialog1.FileName;
                        cantChoosePdfFile = true;
                        pdfFileIsChoosen = true;
                        button3.Enabled = true;
                        //DT.Rows.Add(new object[] { Path.GetFileName(fileName), fileSavePath });
                        //string constr = "Data Source=.;Initial Catalog=master;Integrated Security=True";
                        //using (SqlConnection conn = new SqlConnection(constr))
                        //{
                        //    string sql = "INSERT INTO Files VALUES(@Name, @Path)";
                        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        //    {
                        //        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(fileName));
                        //        cmd.Parameters.AddWithValue("@Path", fileSavePath);
                        //        conn.Open();
                        //        cmd.ExecuteNonQuery();
                        //        conn.Close();
                        //    }
                        //}
                        //DT.Columns.Add("Data", Type.GetType("System.Byte[]"));

                        ////Convert all Images to Byte[] and copy to DataTable.
                        //foreach (DataRow row in DT.Rows)
                        //{
                        //    row["Data"] = File.ReadAllBytes(row["Image"].ToString());
                        //}
                        //dataGridView1.DataSource = DT;
                        // this.BindDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas choisi la fiche technique");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Vous avez déja choisis une fiche technique, voulliez supprimer la fiche existante");
            }           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //string cell = dataGridView1.Rows[0].Cells[0].Value.ToString();

            //// full path required
            //string fileName = (@"..\..\Files\Images\" + cell);
            //if (fileName != null || fileName != string.Empty)
            //{
            //    if ((System.IO.File.Exists(fileName)))
            //    {
            //        System.IO.File.Delete(fileName);
            //        DT.Clear();
            //        dataGridView1.DataSource = DT;
            //    }

            //}
           
            
            DT.Clear();
            dataGridView1.DataSource = DT;
            if (!commingFromUpdateBtn && dataGridView1.Rows.Count > 0)
            {
                DT.Columns.Remove("Nom");
                DT.Columns.Remove("Image");
                DT.Columns.Remove("Data");
                imgFileIsChoosen = false;
                cantChooseImgFile = false;
                commingFromUpdateBtn = false;
            }
            else 
            {
                DT.Columns.Remove("Nom");
                DT.Columns.Remove("Image");
                DT.Columns.Remove("Data");
                imgFileIsChoosen = false;
                cantChooseImgFile = false;
                commingFromUpdateBtn = false;
            }

            if (dataGridView1.Rows.Count > 0)
            {
                DeleteFiles(dataGridView1.Rows[0].Cells[0].Value.ToString(), false);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //string cell = pdffileName;
            // string fileName = (@"..\..\Files\Pdfs\" + cell);
            // if (fileName != null || fileName != string.Empty)
            // {
            //     if ((System.IO.File.Exists(fileName)))
            //     {
            //         System.IO.File.Delete(fileName);
            //         axAcroPDF1.LoadFile("DOESNTEXIST.pdf");
            //         axAcroPDF1.src = null;
            //     }
            //}
            DeleteFiles(pdffileName, true);
            axAcroPDF1.LoadFile("DOESNTEXIST.pdf");
            pdfFileIsChoosen = false;
            cantChoosePdfFile = false;
            //axAcroPDF1.src = "";
            //MessageBox.Show(axAcroPDF1.src.ToString());
        }
    }
}