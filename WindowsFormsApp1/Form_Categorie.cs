using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form_Categorie : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        string FileName;

        public Form_Categorie()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileName = ofd.FileName;
                pictureBox1.Image = new Bitmap(FileName);
                if (textBox_Image.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    textBox_Image.Text = Path.GetFileName(FileName);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into Categorie Values(@nom,@descpt,@img)";
                cmd.Parameters.AddWithValue("@nom", textBox_NomCat.Text);
                cmd.Parameters.AddWithValue("@descpt", textBox_Descrpt.Text);
                cmd.Parameters.AddWithValue("@img", img);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added !!");
            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
