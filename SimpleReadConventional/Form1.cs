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
            _customersBindingSource.DataSource = await DataOperationsConventional.Operations.GetCustomersAsync();
            dataGridView1.DataSource = _customersBindingSource;
            dataGridView1.ExpandColumns();
        }
    }
}
