namespace WindowsFormsApp1
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvImages = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.textBoxLibelle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Titre image";
            // 
            // dgvImages
            // 
            this.dgvImages.AllowUserToAddRows = false;
            this.dgvImages.AllowUserToDeleteRows = false;
            this.dgvImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImages.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvImages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImages.GridColor = System.Drawing.SystemColors.Control;
            this.dgvImages.Location = new System.Drawing.Point(12, 513);
            this.dgvImages.Name = "dgvImages";
            this.dgvImages.ReadOnly = true;
            this.dgvImages.RowTemplate.Height = 30;
            this.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImages.Size = new System.Drawing.Size(1165, 249);
            this.dgvImages.TabIndex = 10;
            this.dgvImages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImages_CellClick);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(26, 56);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(288, 26);
            this.txtTitle.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(618, 386);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(128, 31);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(458, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(320, 56);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 31);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(519, 56);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(476, 310);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 5;
            this.pbxImage.TabStop = false;
            // 
            // textBoxLibelle
            // 
            this.textBoxLibelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLibelle.Location = new System.Drawing.Point(26, 178);
            this.textBoxLibelle.Name = "textBoxLibelle";
            this.textBoxLibelle.Size = new System.Drawing.Size(422, 26);
            this.textBoxLibelle.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = " Libelle";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(26, 249);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(422, 117);
            this.textBoxDescription.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Description";
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(324, 386);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(128, 31);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Liste categories";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxLibelle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.pbxImage);
            this.panel1.Location = new System.Drawing.Point(30, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 452);
            this.panel1.TabIndex = 19;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 794);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvImages);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvImages;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.TextBox textBoxLibelle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}