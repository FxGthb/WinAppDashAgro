using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Categorie : Form
    {
        DataTable DT = new DataTable();
        string fileName;
        private string fileSavePath;
        private bool cantChooseImgFile = false;
        private bool imgFileIsChoosen;
        private bool commingcFromUpdateBtn;
        private string query;
        private Database database;
        private List<Object> list = new List<object>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        private bool commingFromUpdateBtn;
        private string imageName;
        private int imageID;

        public Categorie()
        {
            InitializeComponent();
            database = new Database();
        }

        private void Categorie_Load(object sender, EventArgs e)
        {
            button5.Enabled = true;
            //button3.Enabled = false;
            imgFileIsChoosen = false;
            cantChooseImgFile = false;
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
            dataGridView1.Columns[0].Visible = false;

            //Add a Image Column to the DataGridView at the third position.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";
            imageColumn.DataPropertyName = "Data";
            imageColumn.HeaderText = "Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns.Insert(1, imageColumn);
            dataGridView1.RowTemplate.Height = 200;
            dataGridView1.Columns[1].Width = 200;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                getProducts();
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

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            if (!cantChooseImgFile)
            {
                DT.Clear();
                DT.Dispose();
                dataGridView1.DataSource = DT;
                //DT.Rows.Add(new object[] { "Ravi", 500 });

                //string saveDirectory = @"C:\Users\DELL LATITUDE E5480\Desktop\DataGridView_Image_Path_Database\SavedImages\";
                //string saveDirectory = System.IO.Path.GetDirectoryName("Files");
                string saveDirectory = @"..\..\Files\Images\Categories";
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
                        dataGridView1.Columns[0].Visible = false;
                        text_CatName.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        cantChooseImgFile = true;
                        button2.Enabled = true;
                        // this.BindDataGridView();
                        button5.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas choisi une image");
                    }
                }
            }
            else if (commingcFromUpdateBtn)
            {
                //goto isCommingFromUpdate;
                MessageBox.Show("Haahahahahah exception");
            }
            else
            {
                MessageBox.Show("Vous avez déja choisis une image, voulliez supprimer l'image existante");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //int imgID = 0;
            //insert image produit
            if (DT.Rows.Count > 0)
            {
                query = "INSERT INTO [dbo].[Categories] ([Name],[Desc],[Path],[Cat_Name]) VALUES (@1,@2,@3,@4)";
                string catName = text_CatName.Text.Trim();
                string catDesc = text_CatDesc.Text.Trim();
                list.Clear();
                list.Add(Path.GetFileName(fileName));
                list.Add(catDesc);
                list.Add(fileSavePath);
                list.Add(catName);
                database.openconnection();
                database.insert(query, list);
                database.closeconnecion();
                MessageBox.Show("image Added !!");
                getProducts();
            }
            else MessageBox.Show("Veuillez choisir une image !");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
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
                DeleteFiles(dataGridView1.Rows[0].Cells[0].Value.ToString());
            }
        }
        private void DeleteFiles(string file)
        {
            string cell = file;

            // full path required

            string fileName = (@"..\..\Files\Images\Categories" + cell);
                if (fileName != null || fileName != string.Empty)
                {
                    if ((System.IO.File.Exists(fileName)))
                    {
                        System.IO.File.Delete(fileName);
                        //DT.Clear();
                       DT.Dispose();
                        ///DT = null;
                        dataGridView1.DataSource = DT;
                        getProducts();
                        cantChooseImgFile = false;
                    }

                }
            

        }
        private void getProducts()
        {

            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            query = "SELECT [FileId],[Name] as 'Nom image',[Desc] as 'Description',[Path],[Cat_Name] as 'Nom Categorie' FROM [dbo].[Categories]";
            // SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);
            dataGridView2.DataSource = DT;
            //database.closeconnecion();
            //database.openconnection();
            //dataGridView2.DataSource = database.getData(query, "Produits").Tables["Produits"];
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
            else
            {
                MessageBox.Show("Vous n'avez aucune categorie dans la liste !");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool imgEXIST = false;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("L'image est obligatoire !");
                //imgEXIST = false;
            }

            if (imgFileIsChoosen)
            {
                
                //update image
                
                
                query = "UPDATE [dbo].[Categories] SET [Name] = '"+Path.GetFileName(fileName)+"',[Desc] = '" + text_CatDesc.Text.Trim() + "',[Path] = '" + fileSavePath + "' , [Cat_Name] = '"+ text_CatName.Text.Trim()+"'WHERE dbo.Categories.FileId = @1";
                list.Clear();
                list.Add(imageID);
                database.openconnection();
                database.insert(query, list);
                database.closeconnecion();
                imageName = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                DeleteFiles(imageName);
                MessageBox.Show("image updated !");
                imgEXIST = true;
                imgFileIsChoosen = false;
                getProducts();
            }
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DT.Clear();
            DT.Dispose();
            dataGridView1.DataSource = DT;
            button1.Enabled = true;
            button3.Enabled = true;
            imageID = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            imageName = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_CatDesc.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //Path.GetFileName(fileName) = 
            text_CatName.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            //get image 
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT [Path] FROM [dbo].[Categories] WHERE FileId = '" + imageID+"'", conn))
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
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ete vous sur de supprimer cette categorie : \"" + dataGridView2.CurrentRow.Cells[4].Value.ToString() + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string imgFile = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                query = "DELETE FROM [dbo].[Categories] WHERE Categories.FileId =@1";
                list.Clear();
                list.Add(imageID);
                database.openconnection();
                database.delete(query, list);
                database.closeconnecion();
                DeleteFiles(imgFile);
                getProducts();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
