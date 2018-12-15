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
       
        int idPro = 0;
        private List<Object> list = new List<object>();
        private List<String> listparam = new List<String>();
        int pdfID = 0;
        String strFilePath = "";
        String pdfstrFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        Byte[] pdfByteArray;
        byte[] pdf_pro;
        Byte[] image_pro;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString); 
                
        DataSet dtSet = new DataSet();
        private Database database;

        BindingSource bindingSource = new BindingSource();

        List<string> ListNature = new List<string>();
        List<int> List_ID_Nature = new List<int>();

        #endregion

        public Produit()
        {
            InitializeComponent();
            database = new Database();
        }

        private void buttonAjouterProduit_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 id_cate = (int)listCategories.SelectedValue;
                String libl = libelleProduit.Text.ToString();
                String embal = emballageProduit.Text.ToString();
                String ph = phProduit.Text.ToString();
                String desc = descriptionProduit.Text.ToString();
                String carac = carateristiqueProduit.Text.ToString();

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
                        temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ImageByteArray = strm.ToArray();
                    }
                    image_pro = ImageByteArray;
                }
                else
                    MessageBox.Show("Please enter image title");

                if (txtPDFTitle.Text.Trim() != "")
                {
                    if (pdfstrFilePath == "")
                    {
                        if (pdfByteArray.Length != 0)
                            pdfByteArray = new byte[] { };
                    }
                    else
                    {
                        pdf_pro = File.ReadAllBytes(pdfstrFilePath);
                    }
                }
                else
                    MessageBox.Show("Please enter pdf title");

                Byte[] pdfFle = pdf_pro;
                list.Add(id_cate);
                list.Add(libl);
                list.Add(embal);
                list.Add(ph);
                list.Add(desc);
                list.Add(carac);
                list.Add(image_pro);
                list.Add(pdf_pro);
                listparam.Add("@id_cate");
                listparam.Add("@libl");
                listparam.Add("@embal");
                listparam.Add("@ph");
                listparam.Add("@desc");
                listparam.Add("@carac");
                listparam.Add("@image_pro");
                listparam.Add("@pdf_pro");
                database.openconnection();
                database.insert("Add", list, listparam);
                
            }
            catch (SqlException exception)
            {
                MessageBox.Show("On a pas pu ajouter le produit.Erreur details :\n"+exception.ToString(),"Echec d'insertion",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
            finally
            {
                database.closeconnecion();
            }
            #region add new product proccess
           
        }
        #endregion
        #region formLOAD
        private void Produit_Load(object sender, EventArgs e)
        {
            //Main Main = new Main();
            //this.MdiParent=Main;
            comboBox_Statut.SelectedIndex = 0;            
            try
            {
                listCategories.DisplayMember = "Nom_Categorie";
                listCategories.ValueMember = "ID_Categorie";
                listCategories.SelectedValue = "ID_Categorie";
                database.openconnection();
                listCategories.DataSource = database.select("selectCat", "Categorie").Tables["Categorie"];               
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
            //if (ListNature.Count > 0)
            //{
            //    foreach (var item in ListNature)
            //    {
            //        MessageBox.Show(item);
            //    }
            //}
            //else
            //    MessageBox.Show("Aucun element n'a ete selectionne");
        }

        
    }
}