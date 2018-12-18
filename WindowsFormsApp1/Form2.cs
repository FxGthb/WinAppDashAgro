using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        #region Variables
        int ImageID = 0;
        String strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        //before executing -create database with given script - change connection string according to yours
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        DataTable dtblImages = new DataTable();
        #endregion

        public Form2()
        {
            InitializeComponent();
            DefaultImage = pbxImage.Image;
            buttonDelete.Enabled = false;
            RefreshImageGrid();
        }

        void RefreshImageGrid()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("selectCat", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            sqlda.Fill(dtblImages);
            dgvImages.DataSource = dtblImages;
           // dgvImages.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           dgvImages.Columns[3].Visible = false;
        }

        void Clear()
        {
            ImageID = 0;
            txtTitle.Clear();
            pbxImage.Image = DefaultImage;
            strFilePath = "";
            btnSave.Text = "Save";
            buttonDelete.Enabled = false;
        }

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
            buttonDelete.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            buttonDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() != "")
            {

                if (strFilePath == "")
                {
                    if (ImageByteArray.Length != 0)
                        ImageByteArray = new byte[] { };
                    //Update without image

                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();


                }
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("CatAddOrEdit", sqlcon) { CommandType = CommandType.StoredProcedure };
                /*
                 @Id_categorie INT,
                    @Nom_categorie VARCHAR(50),
                    @Description_categorie VARCHAR(max),
                    @Image
                 */
                sqlCmd.Parameters.Add("@Id_categorie", ImageID);
                sqlCmd.Parameters.Add("@Nom_categorie", textBoxLibelle.Text.Trim());
                sqlCmd.Parameters.Add("@Description_categorie", textBoxDescription.Text.Trim());
                sqlCmd.Parameters.Add("@Image", ImageByteArray);
                sqlCmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Saved successfuly");
                dgvImages.DataSource = null;
                
                Clear();
                RefreshImageGrid();
            }
            else
            {
                MessageBox.Show("Please enter image title");
            }
            buttonDelete.Enabled = false;
        }

        private void dgvImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxLibelle.Text = dgvImages.CurrentRow.Cells[1].Value.ToString();
            textBoxDescription.Text = dgvImages.CurrentRow.Cells[2].Value.ToString();

            txtTitle.Text = dgvImages.CurrentRow.Cells[1].Value.ToString();
            byte[] ImageArray = (byte[])dgvImages.CurrentRow.Cells[3].Value;
            if (ImageArray.Length == 0)
                pbxImage.Image = DefaultImage;
            else
            {
                ImageByteArray = ImageArray;
                pbxImage.Image = Image.FromStream(new MemoryStream(ImageArray));
            }
            ImageID = Convert.ToInt32(dgvImages.CurrentRow.Cells[0].Value);
            btnSave.Text = "Update";
            buttonDelete.Enabled = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
