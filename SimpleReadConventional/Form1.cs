using System;
using System.Data;
using System.Windows.Forms;
using DataGridViewLibrary;
using DataOperationsConventional;

namespace SimpleReadConventional
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _customersBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            _customersBindingSource.DataSource = await Operations.GetCustomersAsync();

            CountryColumn.DisplayMember = "Name";
            CountryColumn.ValueMember = "CountryIdentifier";
            CountryColumn.DataPropertyName = "CountryIdentifier";
            CountryColumn.DataSource = Operations.CountryTable();
            CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            ContactTitleColumn.DisplayMember = "ContactTitle";
            ContactTitleColumn.ValueMember = "ContactTypeIdentifier";
            ContactTitleColumn.DataPropertyName = "ContactTypeIdentifier";
            ContactTitleColumn.DataSource = Operations.ContactTypeTable();
            ContactTitleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            dataGridView1.DataSource = _customersBindingSource;
            dataGridView1.ExpandColumns();

            CountryNamesComboBox.DataSource = Operations.CountryNameList();
            CountryNamesComboBox.SelectedIndex = 1;
        }

        private void CurrentCustomerButton_Click(object sender, EventArgs e)
        {

            if (_customersBindingSource.DataSource != null && _customersBindingSource.Current != null)
            {
                var customer = ((DataRowView) _customersBindingSource.Current).Row;
                MessageBox.Show($"Id: {customer.Field<int>("CustomerIdentifier")}" + 
                                $"\nContact Id: {customer.Field<int>("ContactId")}");

            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (CountryNamesComboBox.DataSource == null) return;

            if (CountryNamesComboBox.Text == @"Remove filter")
            {
                _customersBindingSource.Filter = "";
            }
            else
            {
                _customersBindingSource.Filter = $"CountryName = '{CountryNamesComboBox.Text}'";
            }

        }
    }
}
