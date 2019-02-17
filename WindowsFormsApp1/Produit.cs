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
        //int pdfID = 0;
        String strFilePath = "";
        String pdfstrFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        Byte[] pdfByteArray;
        byte[] pdf_pro;
        Byte[] image_pro;
        string fileName;
        private string fileSavePath;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString); 
                
        DataSet dtSet = new DataSet();
        private Database database;

        BindingSource bindingSource = new BindingSource();

        List<string> ListNature = new List<string>();
        List<int> List_ID_Nature = new List<int>();

        string ProdName;
        private string query;
        private string pdffileName;
        private string pdffileSavePath;
        private int imageID;
        private int pdfID;
        private string imageName;
        private string pdfName;

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

        public void UpdateProd(List<Object> listofcontrols)
        {
            buttonUpdateProduit.Enabled = true;
            buttonAjouterProduit.Enabled = false;
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
            //MessageBox.Show(imageName);
            //txtImgTitle.Text = listofcontrols[8].ToString();
            /*
                byte[] imageSource = **byte array**;
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(imageSource))
                {
                   image = new Bitmap(stream);
                }
                pictureBox.Image = image;
             */
            //byte[] ImageArray = bytes;
            //Bitmap image;
            //using (MemoryStream stream = new MemoryStream(ImageArray))
            //{
            //    image = new Bitmap(stream);
            //}
            //pbxImage.Image = image;
            //if (ImageArray.Length == 0)
            //    pbxImage.Image = DefaultImage;
            //else
            //{
            //    ImageByteArray = ImageArray;
            //    pbxImage.Image = pbxImage.(ImageArray));
            //}
            //ImageID = Convert.ToInt32(dgvImages.CurrentRow.Cells[0].Value);
            carateristiqueProduit.Text = listofcontrols[6].ToString();
            index = listCategories.FindString(listofcontrols[1].ToString());
            listCategories.SelectedIndex = index;
            //get image 
             using (SqlDataAdapter sda = new SqlDataAdapter("SELECT i.FileId, i.Name, i.Path FROM[agroV2].[dbo].[Images] as i" +
                        " join dbo.Produits as p on i.FileId = p.img_produit where p.ID_Produit = '"+idPro+"'", conn))
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
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT pdf.FileId, pdf.Name, pdf.Path FROM[agroV2].[dbo].[Pdfs] as pdf" +
                       " join dbo.Produits as p on pdf.FileId = p.img_produit where p.ID_Produit = '" + idPro + "'", conn))
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

                axAcroPDF1.LoadFile( dt.Rows[0][2].ToString());
                //dataGridView1.Rows[0].Cells[0].Value = dt.Rows[0][1];
            }


        }

        private void buttonAjouterProduit_Click(object sender, EventArgs e)
        {
            int imgID = 0;
            int pdfID = 0;
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
                else MessageBox.Show("please choose product image !");

                if (axAcroPDF1.src != null)
                {
                    query = "INSERT INTO [dbo].[Pdfs] ([Name],[Path]) VALUES (@1,@2)";
                    list.Clear();
                    list.Add(Path.GetFileName(pdffileName));
                    list.Add(pdffileSavePath);
                    database.openconnection();
                    database.insert(query, list);
                    MessageBox.Show("pdf Added !!");
                    database.closeconnecion();

                    //get pdf id
                    query = "SELECT MAX(FileId) as 'pdfID' FROM Pdfs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        conn.Open();
                        pdfID = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }
                else MessageBox.Show("please choose product pdf !");

                if (imgID !=0 && pdfID != 0)
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
                    
                    database.openconnection();
                    database.insert(query, list);
                    MessageBox.Show("product Added !!");
                    database.closeconnecion();
                    DT.Clear();
                    axAcroPDF1.LoadFile("DOESNTEXIST.pdf");
                    axAcroPDF1.src = null;
                    listCategories.SelectedIndex = -1;
                }

            }
            catch (SqlException exception)
            {
                MessageBox.Show("On a pas pu ajouter le produit.Erreur details :\n"+exception.ToString(),"Echec d'insertion",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
            finally
            {
                database.closeconnecion();
                list.Clear();
                listparam.Clear();
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
            #region add new product proccess
           
        }
        #endregion
        #region formLOAD
        private void Produit_Load(object sender, EventArgs e)
        {
            buttonUpdateProduit.Enabled = false;
            buttonAjouterProduit.Enabled = true;
            if (ProdName != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * from Produit where Libelle ='"+ProdName+"'";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                 
            }
            else
            {
                comboBox_Statut.SelectedIndex = 0;
                try
                {
                    listCategories.DisplayMember = "Nom_Categorie";
                    listCategories.ValueMember = "ID_Categorie";
                    listCategories.SelectedValue = "ID_Categorie";
                    query = "SELECT [ID_Categorie] ,[Nom_Categorie] ,[Description_Categorie] FROM [dbo].[Categorie]";
                    database.openconnection();
                    listCategories.DataSource = database.getData(query, "Categorie").Tables["Categorie"];
                    listCategories.SelectedIndex = -1;
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
        #endregion

        //#region button browse image clickEvent()
        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        strFilePath = ofd.FileName;
        //        pbxImage.Image = new Bitmap(strFilePath);
        //        if (txtImgTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
        //            txtImgTitle.Text = System.IO.Path.GetFileName(strFilePath);
        //    }
        //}
        //#endregion

        //#region browse pdf clickEvent()
        //private void btnBrowsePdf_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Pdf Files|*.pdf";
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        pdfstrFilePath = ofd.FileName;
        //        //pbxImage.Image = new Bitmap(strFilePath);
        //        if (txtPDFTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
        //            txtPDFTitle.Text = System.IO.Path.GetFileName(pdfstrFilePath);
        //    }

        //}
        //#endregion

        private void chelistbox_nature_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            //    ListNature.Add(chelistbox_nature.Items[e.Index].ToString());
            //else
            //{
            //    if (e.Index != 0)
            //        ListNature.RemoveAt(e.Index);
            //    else
            //        ListNature.Clear();
            //}
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ButtonUpdateProduit_Click(object sender, EventArgs e)
        {
            //if (txtImgTitle.Text.Trim() != "")
            //{
            //    if (strFilePath == "")
            //    {
            //        if (ImageByteArray.Length != 0)
            //            ImageByteArray = new byte[] { };
            //    }
            //    else
            //    {
            //        Image temp = new Bitmap(strFilePath);
            //        MemoryStream strm = new MemoryStream();
            //        temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        ImageByteArray = strm.ToArray();
            //    }
            //    image_pro = ImageByteArray;

            //update image
            DeleteFiles(imageName, false);
            query = "UPDATE [dbo].[Images] SET [Name] = '"+ Path.GetFileName(fileName) + "',[Path] = '"+ fileSavePath + "' WHERE Images.FileId = @1 ";
            list.Clear();
            list.Add(imageID);
            database.openconnection();
            database.insert(query, list);
            database.closeconnecion();            
            MessageBox.Show("image updated !");

            //update pdf
            DeleteFiles(pdfName, true);
            query = "UPDATE [dbo].[Pdfs] SET [Name] = '" + Path.GetFileName(pdffileName) + "',[Path] = '" + pdffileSavePath + "' WHERE Pdfs.FileId = @1 ";
            list.Clear();
            list.Add(pdfID);
            database.openconnection();
            database.insert(query, list);
            database.closeconnecion();
            MessageBox.Show("pdf updated !");

            // update product

            //}
            //else
            //    MessageBox.Show("Please enter image title");



        }        

        private void DeleteFiles(string file, bool isPDF)
        {
            string cell = file;
            string fileName=null;
            // full path required
            if (isPDF)
            {
                fileName = (@"..\..\Files\Pdfs\" + cell);
            }
            else
            fileName = (@"..\..\Files\Images\" + cell);
            if (fileName != null || fileName != string.Empty)
            {
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);
                    DT.Clear();
                    dataGridView1.DataSource = DT;
                }

            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            //Button2_Click(sender,e);
            DT.Clear();
            dataGridView1.DataSource = DT;
            DT.Columns.Add("Nom");
            DT.Columns.Add("Image");
            //DT.Rows.Add(new object[] { "Ravi", 500 });

            //string saveDirectory = @"C:\Users\DELL LATITUDE E5480\Desktop\DataGridView_Image_Path_Database\SavedImages\";
            //string saveDirectory = System.IO.Path.GetDirectoryName("Files");
            string saveDirectory = @"..\..\Files\Images\";
            //string documents = Directory.GetDirectories("../..Files");
            //string[] files = File.ReadAllLines(path);
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                     fileName = Path.GetFileName(openFileDialog1.FileName);
                    fileSavePath = Path.Combine(saveDirectory, fileName);
                    File.Copy(openFileDialog1.FileName, fileSavePath, true);

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
                    DT.Columns.Add("Data", Type.GetType("System.Byte[]"));

                    //Convert all Images to Byte[] and copy to DataTable.
                    foreach (DataRow row in DT.Rows)
                    {
                        row["Data"] = File.ReadAllBytes(row["Image"].ToString());
                    }
                    dataGridView1.DataSource = DT;
                   // this.BindDataGridView();
                }
            }
        }

        private void BindDataGridView()
        {
            string constr = "Data Source=.;Initial Catalog=master;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Files", conn))
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
                }
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
            //Button3_Click(sender, e);
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
            DeleteFiles(dataGridView1.Rows[0].Cells[0].Value.ToString(), false);
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
        }
    }
}