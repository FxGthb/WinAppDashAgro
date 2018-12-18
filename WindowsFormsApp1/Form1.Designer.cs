namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drvProduits = new System.Windows.Forms.DataGridView();
            this.txbLibelle = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listCategories = new System.Windows.Forms.ComboBox();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agroPartnersDataSet = new WindowsFormsApp1.AgroPartnersDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.Libelle = new System.Windows.Forms.Label();
            this.natureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_PDF = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.natureTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.NatureTableAdapter();
            this.categorieTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.CategorieTableAdapter();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.drvProduits)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drvProduits
            // 
            this.drvProduits.AllowUserToAddRows = false;
            this.drvProduits.AllowUserToDeleteRows = false;
            this.drvProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvProduits.Location = new System.Drawing.Point(12, 163);
            this.drvProduits.Name = "drvProduits";
            this.drvProduits.ReadOnly = true;
            this.drvProduits.Size = new System.Drawing.Size(1026, 370);
            this.drvProduits.TabIndex = 0;
            this.drvProduits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drvProduits_CellClick);
            this.drvProduits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drvProduits_CellContentClick_1);
            // 
            // txbLibelle
            // 
            this.txbLibelle.Location = new System.Drawing.Point(82, 14);
            this.txbLibelle.Name = "txbLibelle";
            this.txbLibelle.Size = new System.Drawing.Size(332, 20);
            this.txbLibelle.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(230, 91);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(184, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Rechercher";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listCategories);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Libelle);
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.txbLibelle);
            this.panel1.Location = new System.Drawing.Point(301, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 133);
            this.panel1.TabIndex = 6;
            // 
            // listCategories
            // 
            this.listCategories.DataSource = this.categorieBindingSource;
            this.listCategories.DisplayMember = "Nom_Categorie";
            this.listCategories.FormattingEnabled = true;
            this.listCategories.Location = new System.Drawing.Point(82, 53);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(331, 21);
            this.listCategories.TabIndex = 6;
            this.listCategories.ValueMember = "ID_Categorie";
            this.listCategories.SelectedIndexChanged += new System.EventHandler(this.listCategories_SelectedIndexChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Catégorie";
            // 
            // Libelle
            // 
            this.Libelle.AutoSize = true;
            this.Libelle.Location = new System.Drawing.Point(22, 17);
            this.Libelle.Name = "Libelle";
            this.Libelle.Size = new System.Drawing.Size(37, 13);
            this.Libelle.TabIndex = 3;
            this.Libelle.Text = "Libelle";
            // 
            // natureBindingSource
            // 
            this.natureBindingSource.DataMember = "Nature";
            this.natureBindingSource.DataSource = this.agroPartnersDataSet;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_PDF);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(639, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 56);
            this.panel2.TabIndex = 7;
            // 
            // button_PDF
            // 
            this.button_PDF.Location = new System.Drawing.Point(22, 17);
            this.button_PDF.Name = "button_PDF";
            this.button_PDF.Size = new System.Drawing.Size(75, 23);
            this.button_PDF.TabIndex = 9;
            this.button_PDF.Text = "PDF";
            this.button_PDF.UseVisualStyleBackColor = true;
            this.button_PDF.Click += new System.EventHandler(this.button_PDF_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(200, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(110, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "New";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // natureTableAdapter
            // 
            this.natureTableAdapter.ClearBeforeFill = true;
            // 
            // categorieTableAdapter
            // 
            this.categorieTableAdapter.ClearBeforeFill = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(135, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 603);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.drvProduits);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drvProduits)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView drvProduits;
        private System.Windows.Forms.TextBox txbLibelle;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Libelle;
        private System.Windows.Forms.ComboBox listCategories;
        private System.Windows.Forms.Panel panel2;
        private AgroPartnersDataSet agroPartnersDataSet;
        private System.Windows.Forms.BindingSource natureBindingSource;
        private AgroPartnersDataSetTableAdapters.NatureTableAdapter natureTableAdapter;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private AgroPartnersDataSetTableAdapters.CategorieTableAdapter categorieTableAdapter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button_PDF;
    }
}

