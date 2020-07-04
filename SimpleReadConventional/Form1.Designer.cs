namespace SimpleReadConventional
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomerIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTypeIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerIdentifierColumn,
            this.CompanyNameColumn,
            this.ContactIdColumn,
            this.FirstNameColumn,
            this.LastNameColumn,
            this.ContactTitleColumn,
            this.ContactTypeIdentifierColumn,
            this.CountryIdentifierColumn,
            this.CountryNameColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 356);
            this.dataGridView1.TabIndex = 0;
            // 
            // CustomerIdentifierColumn
            // 
            this.CustomerIdentifierColumn.DataPropertyName = "CustomerIdentifier";
            this.CustomerIdentifierColumn.HeaderText = "Company id";
            this.CustomerIdentifierColumn.Name = "CustomerIdentifierColumn";
            this.CustomerIdentifierColumn.Visible = false;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            // 
            // ContactIdColumn
            // 
            this.ContactIdColumn.DataPropertyName = "ContactId";
            this.ContactIdColumn.HeaderText = "Contact Id";
            this.ContactIdColumn.Name = "ContactIdColumn";
            this.ContactIdColumn.Visible = false;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First name";
            this.FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last name";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // ContactTitleColumn
            // 
            this.ContactTitleColumn.DataPropertyName = "ContactTitle";
            this.ContactTitleColumn.HeaderText = "Title";
            this.ContactTitleColumn.Name = "ContactTitleColumn";
            // 
            // ContactTypeIdentifierColumn
            // 
            this.ContactTypeIdentifierColumn.DataPropertyName = "ContactTypeIdentifier";
            this.ContactTypeIdentifierColumn.HeaderText = "Contact Type Id";
            this.ContactTypeIdentifierColumn.Name = "ContactTypeIdentifierColumn";
            this.ContactTypeIdentifierColumn.Visible = false;
            // 
            // CountryIdentifierColumn
            // 
            this.CountryIdentifierColumn.DataPropertyName = "CountryIdentifier";
            this.CountryIdentifierColumn.HeaderText = "Country Id";
            this.CountryIdentifierColumn.Name = "CountryIdentifierColumn";
            this.CountryIdentifierColumn.Visible = false;
            // 
            // CountryNameColumn
            // 
            this.CountryNameColumn.DataPropertyName = "CountryName";
            this.CountryNameColumn.HeaderText = "Country";
            this.CountryNameColumn.Name = "CountryNameColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 356);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple conventional read";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerIdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactTypeIdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryIdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryNameColumn;
    }
}

