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
            this.txbLibelle = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.listCategories = new System.Windows.Forms.ComboBox();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agroPartnersDataSet = new WindowsFormsApp1.AgroPartnersDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.Libelle = new System.Windows.Forms.Label();
            this.natureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.natureTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.NatureTableAdapter();
            this.categorieTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.CategorieTableAdapter();
            this.drvProduits = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_PDF = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drvProduits)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbLibelle
            // 
            this.txbLibelle.Location = new System.Drawing.Point(67, 19);
            this.txbLibelle.Name = "txbLibelle";
            this.txbLibelle.Size = new System.Drawing.Size(250, 20);
            this.txbLibelle.TabIndex = 1;
            this.txbLibelle.TextChanged += new System.EventHandler(this.TxbLibelle_TextChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(169, 171);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(184, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Rechercher";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // listCategories
            // 
            this.listCategories.DataSource = this.categorieBindingSource;
            this.listCategories.DisplayMember = "Nom_Categorie";
            this.listCategories.FormattingEnabled = true;
            this.listCategories.Location = new System.Drawing.Point(67, 54);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(250, 21);
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
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Catégorie";
            // 
            // Libelle
            // 
            this.Libelle.AutoSize = true;
            this.Libelle.Location = new System.Drawing.Point(7, 22);
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
            // natureTableAdapter
            // 
            this.natureTableAdapter.ClearBeforeFill = true;
            // 
            // categorieTableAdapter
            // 
            this.categorieTableAdapter.ClearBeforeFill = true;
            // 
            // drvProduits
            // 
            this.drvProduits.AllowUserToAddRows = false;
            this.drvProduits.AllowUserToDeleteRows = false;
            this.drvProduits.AllowUserToOrderColumns = true;
            this.drvProduits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvProduits.Location = new System.Drawing.Point(12, 222);
            this.drvProduits.Name = "drvProduits";
            this.drvProduits.ReadOnly = true;
            this.drvProduits.Size = new System.Drawing.Size(1026, 322);
            this.drvProduits.TabIndex = 9;
            this.drvProduits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DrvProduits_CellContentClick_1);
            this.drvProduits.SelectionChanged += new System.EventHandler(this.DrvProduits_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbLibelle);
            this.groupBox1.Controls.Add(this.Libelle);
            this.groupBox1.Controls.Add(this.listCategories);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 153);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // button_PDF
            // 
            this.button_PDF.Location = new System.Drawing.Point(579, 573);
            this.button_PDF.Name = "button_PDF";
            this.button_PDF.Size = new System.Drawing.Size(75, 23);
            this.button_PDF.TabIndex = 14;
            this.button_PDF.Text = "PDF";
            this.button_PDF.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(757, 573);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(855, 573);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 573);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "New";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 624);
            this.Controls.Add(this.button_PDF);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.drvProduits);
            this.Controls.Add(this.searchBtn);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drvProduits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txbLibelle;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Libelle;
        private System.Windows.Forms.ComboBox listCategories;
        private AgroPartnersDataSet agroPartnersDataSet;
        private System.Windows.Forms.BindingSource natureBindingSource;
        private AgroPartnersDataSetTableAdapters.NatureTableAdapter natureTableAdapter;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private AgroPartnersDataSetTableAdapters.CategorieTableAdapter categorieTableAdapter;
        private System.Windows.Forms.DataGridView drvProduits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_PDF;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

