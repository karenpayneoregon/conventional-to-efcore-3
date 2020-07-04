using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewLibrary;
using DataOperationsEntityFrameworkCore.Classes;
using DataOperationsEntityFrameworkCore.Contexts;
using DataOperationsEntityFrameworkCore.Projections;
using Equin.ApplicationFramework;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
            dataGridView1.DataSource = _customersBindingSource;
            dataGridView1.ExpandColumns();

            CountryNamesComboBox.DataSource = Operations.CountryNameList();
            CountryNamesComboBox.SelectedIndex = 1;
        }

        private void CurrentCustomerButton_Click(object sender, EventArgs e)
        {
            if (_customersBindingSource.DataSource != null)
            {
                var customer = _customerView[_customersBindingSource.Position].Object;
                MessageBox.Show($"Id: {customer.CustomerIdentifier}\nContact Id: {customer.ContactId}");
            }
        }
        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (CountryNamesComboBox.DataSource == null) return;

            if (CountryNamesComboBox.Text == "Remove filter")
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
