using System;
using System.Windows.Forms;
using DataGridViewLibrary;
using DataOperationsEntityFrameworkCore.Classes;
using DataOperationsEntityFrameworkCore.Projections;
using Equin.ApplicationFramework;

namespace SimpleReadEntityFrameworkCore
{
    public partial class Form1 : Form
    {
        private BindingListView<CustomerItem> _customerView; 
        private readonly BindingSource _customersBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            Shown += Form1_Shown;
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            _customerView = new BindingListView<CustomerItem>(await Operations.GetCustomersAsync());
            
            _customersBindingSource.DataSource = _customerView;

            CountryColumn.DisplayMember = "Name";
            CountryColumn.ValueMember = "CountryIdentifier";
            CountryColumn.DataPropertyName = "CountryIdentifier";
            CountryColumn.DataSource = Operations.Countries();
            CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            ContactTitleColumn.DisplayMember = "ContactTitle";
            ContactTitleColumn.ValueMember = "ContactTypeIdentifier";
            ContactTitleColumn.DataPropertyName = "ContactTypeIdentifier";
            ContactTitleColumn.DataSource = Operations.ContactTypes();
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
                var customer = _customerView[_customersBindingSource.Position].Object;
                MessageBox.Show($"Id: {customer.CustomerIdentifier}\nContact Id: {customer.ContactId}");
            }
        }
        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (CountryNamesComboBox.DataSource == null) return;

            if (CountryNamesComboBox.Text == @"Remove filter")
            {
                _customerView.RemoveFilter();
            }
            else
            {
                _customerView.ApplyFilter(customer => customer.CountryName == CountryNamesComboBox.Text);
            }
        }
    }
}
