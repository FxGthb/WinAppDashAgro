namespace WindowsFormsApp1
{
    partial class Produit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_Statut = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.phProduit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emballageProduit = new System.Windows.Forms.TextBox();
            this.listCategories = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.libelleProduit = new System.Windows.Forms.TextBox();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agroPartnersDataSet = new WindowsFormsApp1.AgroPartnersDataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.carateristiqueProduit = new System.Windows.Forms.TextBox();
            this.descriptionProduit = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_List_Prod = new System.Windows.Forms.Button();
            this.buttonAjouterProduit = new System.Windows.Forms.Button();
            this.categorieTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.CategorieTableAdapter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBrowsePdf = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPDFTitle = new System.Windows.Forms.TextBox();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImgTitle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catégorie";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.comboBox_Statut);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.phProduit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.emballageProduit);
            this.panel1.Controls.Add(this.listCategories);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.libelleProduit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 239);
            this.panel1.TabIndex = 2;
            // 
            // comboBox_Statut
            // 
            this.comboBox_Statut.FormattingEnabled = true;
            this.comboBox_Statut.ItemHeight = 13;
            this.comboBox_Statut.Items.AddRange(new object[] {
            "Active",
            "En veille"});
            this.comboBox_Statut.Location = new System.Drawing.Point(121, 201);
            this.comboBox_Statut.MaxDropDownItems = 6;
            this.comboBox_Statut.Name = "comboBox_Statut";
            this.comboBox_Statut.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Statut.Sorted = true;
            this.comboBox_Statut.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Statut";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "PH";
            // 
            // phProduit
            // 
            this.phProduit.Location = new System.Drawing.Point(121, 164);
            this.phProduit.Name = "phProduit";
            this.phProduit.Size = new System.Drawing.Size(100, 20);
            this.phProduit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Emballage";
            // 
            // emballageProduit
            // 
            this.emballageProduit.Location = new System.Drawing.Point(121, 115);
            this.emballageProduit.Name = "emballageProduit";
            this.emballageProduit.Size = new System.Drawing.Size(100, 20);
            this.emballageProduit.TabIndex = 3;
            // 
            // listCategories
            // 
            this.listCategories.FormattingEnabled = true;
            this.listCategories.Location = new System.Drawing.Point(121, 19);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(121, 21);
            this.listCategories.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Libelle";
            // 
            // libelleProduit
            // 
            this.libelleProduit.Location = new System.Drawing.Point(121, 63);
            this.libelleProduit.Name = "libelleProduit";
            this.libelleProduit.Size = new System.Drawing.Size(101, 20);
            this.libelleProduit.TabIndex = 2;
            // 
            // categorieBindingSource
            // 
            this.categorieBindingSource.DataMember = "Categorie";
            this.categorieBindingSource.DataSource = this.agroPartnersDataSet;
            // 
            // agroPartnersDataSet
            // 
            this.agroPartnersDataSet.DataSetName = "AgroPartnersDataSet";
            this.agroPartnersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.carateristiqueProduit);
            this.panel2.Controls.Add(this.descriptionProduit);
            this.panel2.Location = new System.Drawing.Point(346, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 417);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Caracteristiques";
            // 
            // carateristiqueProduit
            // 
            this.carateristiqueProduit.Location = new System.Drawing.Point(9, 184);
            this.carateristiqueProduit.Multiline = true;
            this.carateristiqueProduit.Name = "carateristiqueProduit";
            this.carateristiqueProduit.Size = new System.Drawing.Size(426, 230);
            this.carateristiqueProduit.TabIndex = 7;
            // 
            // descriptionProduit
            // 
            this.descriptionProduit.Location = new System.Drawing.Point(9, 32);
            this.descriptionProduit.Multiline = true;
            this.descriptionProduit.Name = "descriptionProduit";
            this.descriptionProduit.Size = new System.Drawing.Size(426, 122);
            this.descriptionProduit.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.button_List_Prod);
            this.panel3.Controls.Add(this.buttonAjouterProduit);
            this.panel3.Location = new System.Drawing.Point(346, 456);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 56);
            this.panel3.TabIndex = 4;
            // 
            // button_List_Prod
            // 
            this.button_List_Prod.Location = new System.Drawing.Point(264, 18);
            this.button_List_Prod.Name = "button_List_Prod";
            this.button_List_Prod.Size = new System.Drawing.Size(75, 23);
            this.button_List_Prod.TabIndex = 1;
            this.button_List_Prod.Text = "List";
            this.button_List_Prod.UseVisualStyleBackColor = true;
            this.button_List_Prod.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAjouterProduit
            // 
            this.buttonAjouterProduit.Location = new System.Drawing.Point(345, 18);
            this.buttonAjouterProduit.Name = "buttonAjouterProduit";
            this.buttonAjouterProduit.Size = new System.Drawing.Size(75, 23);
            this.buttonAjouterProduit.TabIndex = 0;
            this.buttonAjouterProduit.Text = "Ajouter";
            this.buttonAjouterProduit.UseVisualStyleBackColor = true;
            this.buttonAjouterProduit.Click += new System.EventHandler(this.buttonAjouterProduit_Click);
            // 
            // categorieTableAdapter
            // 
            this.categorieTableAdapter.ClearBeforeFill = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.btnBrowsePdf);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtPDFTitle);
            this.panel4.Controls.Add(this.pbxImage);
            this.panel4.Controls.Add(this.btnBrowse);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtImgTitle);
            this.panel4.Location = new System.Drawing.Point(20, 260);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(301, 252);
            this.panel4.TabIndex = 5;
            // 
            // btnBrowsePdf
            // 
            this.btnBrowsePdf.Location = new System.Drawing.Point(227, 196);
            this.btnBrowsePdf.Name = "btnBrowsePdf";
            this.btnBrowsePdf.Size = new System.Drawing.Size(57, 21);
            this.btnBrowsePdf.TabIndex = 6;
            this.btnBrowsePdf.Text = "Parcourir";
            this.btnBrowsePdf.UseVisualStyleBackColor = true;
            this.btnBrowsePdf.Click += new System.EventHandler(this.btnBrowsePdf_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Documentattion";
            // 
            // txtPDFTitle
            // 
            this.txtPDFTitle.Location = new System.Drawing.Point(121, 196);
            this.txtPDFTitle.Name = "txtPDFTitle";
            this.txtPDFTitle.Size = new System.Drawing.Size(100, 20);
            this.txtPDFTitle.TabIndex = 4;
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(24, 42);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(260, 130);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImage.TabIndex = 3;
            this.pbxImage.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(227, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 21);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Parcourir";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Image produit";
            // 
            // txtImgTitle
            // 
            this.txtImgTitle.Location = new System.Drawing.Point(121, 13);
            this.txtImgTitle.Name = "txtImgTitle";
            this.txtImgTitle.Size = new System.Drawing.Size(100, 20);
            this.txtImgTitle.TabIndex = 0;
            // 
            // Produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 527);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Produit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Produit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phProduit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emballageProduit;
        private System.Windows.Forms.ComboBox listCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox libelleProduit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox carateristiqueProduit;
        private System.Windows.Forms.TextBox descriptionProduit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAjouterProduit;
        private AgroPartnersDataSet agroPartnersDataSet;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private AgroPartnersDataSetTableAdapters.CategorieTableAdapter categorieTableAdapter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImgTitle;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowsePdf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPDFTitle;
        private System.Windows.Forms.Button button_List_Prod;
        private System.Windows.Forms.ComboBox comboBox_Statut;
    }
}