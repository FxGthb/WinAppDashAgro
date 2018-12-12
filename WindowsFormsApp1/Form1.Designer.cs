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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txbLibelle = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Libelle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.agroPartnersDataSet = new WindowsFormsApp1.AgroPartnersDataSet();
            this.natureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.natureTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.NatureTableAdapter();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categorieTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.CategorieTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 370);
            this.dataGridView1.TabIndex = 0;
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
            this.searchBtn.Location = new System.Drawing.Point(230, 137);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(184, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Rechercher";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(545, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(464, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(383, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "New";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.cmbCategorie);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Libelle);
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.txbLibelle);
            this.panel1.Location = new System.Drawing.Point(301, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 189);
            this.panel1.TabIndex = 6;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Catégorie";
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.DataSource = this.categorieBindingSource;
            this.cmbCategorie.DisplayMember = "Nom_Categorie";
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(82, 53);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(331, 21);
            this.cmbCategorie.TabIndex = 6;
            this.cmbCategorie.ValueMember = "ID_Categorie";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.natureBindingSource;
            this.comboBox1.DisplayMember = "Description_Nature";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(82, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(330, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "ID_Nature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nature";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(277, 584);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 35);
            this.panel2.TabIndex = 7;
            // 
            // agroPartnersDataSet
            // 
            this.agroPartnersDataSet.DataSetName = "AgroPartnersDataSet";
            this.agroPartnersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // categorieBindingSource
            // 
            this.categorieBindingSource.DataMember = "Categorie";
            this.categorieBindingSource.DataSource = this.agroPartnersDataSet;
            // 
            // categorieTableAdapter
            // 
            this.categorieTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 670);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.natureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txbLibelle;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Libelle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Panel panel2;
        private AgroPartnersDataSet agroPartnersDataSet;
        private System.Windows.Forms.BindingSource natureBindingSource;
        private AgroPartnersDataSetTableAdapters.NatureTableAdapter natureTableAdapter;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private AgroPartnersDataSetTableAdapters.CategorieTableAdapter categorieTableAdapter;
    }
}

