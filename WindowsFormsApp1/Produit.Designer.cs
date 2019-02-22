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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produit));
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
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.buttonUpdateProduit = new System.Windows.Forms.Button();
            this.button_List_Prod = new System.Windows.Forms.Button();
            this.buttonAjouterProduit = new System.Windows.Forms.Button();
            this.categorieTableAdapter = new WindowsFormsApp1.AgroPartnersDataSetTableAdapters.CategorieTableAdapter();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agroPartnersDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(47, 23);
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
            this.panel2.Location = new System.Drawing.Point(365, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 311);
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
            this.carateristiqueProduit.Size = new System.Drawing.Size(358, 99);
            this.carateristiqueProduit.TabIndex = 7;
            // 
            // descriptionProduit
            // 
            this.descriptionProduit.Location = new System.Drawing.Point(9, 32);
            this.descriptionProduit.Multiline = true;
            this.descriptionProduit.Name = "descriptionProduit";
            this.descriptionProduit.Size = new System.Drawing.Size(358, 75);
            this.descriptionProduit.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.Cancel_btn);
            this.panel3.Controls.Add(this.buttonUpdateProduit);
            this.panel3.Controls.Add(this.button_List_Prod);
            this.panel3.Controls.Add(this.buttonAjouterProduit);
            this.panel3.Location = new System.Drawing.Point(636, 340);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 147);
            this.panel3.TabIndex = 4;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(20, 44);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Annuler";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // buttonUpdateProduit
            // 
            this.buttonUpdateProduit.Location = new System.Drawing.Point(20, 73);
            this.buttonUpdateProduit.Name = "buttonUpdateProduit";
            this.buttonUpdateProduit.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateProduit.TabIndex = 2;
            this.buttonUpdateProduit.Text = "Modifier";
            this.buttonUpdateProduit.UseVisualStyleBackColor = true;
            this.buttonUpdateProduit.Click += new System.EventHandler(this.ButtonUpdateProduit_Click);
            // 
            // button_List_Prod
            // 
            this.button_List_Prod.Location = new System.Drawing.Point(20, 102);
            this.button_List_Prod.Name = "button_List_Prod";
            this.button_List_Prod.Size = new System.Drawing.Size(75, 23);
            this.button_List_Prod.TabIndex = 1;
            this.button_List_Prod.Text = "List";
            this.button_List_Prod.UseVisualStyleBackColor = true;
            this.button_List_Prod.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAjouterProduit
            // 
            this.buttonAjouterProduit.Location = new System.Drawing.Point(20, 15);
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
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(48, 268);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChoose.Size = new System.Drawing.Size(107, 23);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "Choose png File";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 297);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(264, 131);
            this.dataGridView1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(762, 46);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Choose pdf File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(762, 72);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(607, 666);
            this.axAcroPDF1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1346, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 750);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_List_Prod;
        private System.Windows.Forms.ComboBox comboBox_Statut;
        private System.Windows.Forms.Button buttonUpdateProduit;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button button1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}