using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperationsConventional
{
    public class Operations
    {
        /// <summary>
        /// Connection string for database and the catalog to work with
        /// </summary>
        private static string ConnectionString =
            "Data Source=.\\SQLEXPRESS;" +
            "Initial Catalog=NorthWindAzureForInserts;" +
            "Integrated Security=True";

        /// <summary>
        /// Get all customers ordered by company name
        /// </summary>
        /// <returns></returns>
        public static async Task<DataTable> GetCustomersAsync()
        {

            var dataTable = new DataTable();

            await Task.Run(async () =>
            {

                using (var cn = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand() { Connection = cn })
                    {
                        cmd.CommandText = 
                            "SELECT  cust.CustomerIdentifier, cust.CompanyName, cust.ContactId, Contacts.FirstName, " + 
                            "Contacts.LastName, ct.ContactTitle, cust.ContactTypeIdentifier, cust.CountryIdentifier, " + 
                            "Countries.Name AS CountryName FROM Customers AS cust " + 
                            "INNER JOIN Contacts ON cust.ContactId = Contacts.ContactId " + 
                            "INNER JOIN ContactType AS ct ON cust.ContactTypeIdentifier = ct.ContactTypeIdentifier " + 
                            "INNER JOIN Countries ON cust.CountryIdentifier = Countries.CountryIdentifier " +
                            "ORDER BY cust.CompanyName";

                        await cn.OpenAsync();
                        dataTable.Load(await cmd.ExecuteReaderAsync());
                    }
                }

            });

            return dataTable;
        }
        /// <summary>
        /// Get all company names for filtering
        /// </summary>
        /// <returns></returns>
        public static List<string> CountryNameList()
        {
            List<string> countryNames = new List<string>();

            using (var cn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand() {Connection = cn})
                {
                    cmd.CommandText = "SELECT Name AS countryName FROM dbo.Countries;";
                    cn.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        countryNames.Add(reader.GetString(0));
                    }
                }
            }


            countryNames.Insert(0, "Remove filter");

            return countryNames;
        }
        /// <summary>
        /// Get all Countries for DataGridView ComboBox column
        /// </summary>
        /// <returns></returns>
        public static DataTable CountryTable()
        {
            var dt = new DataTable();
            using (var cn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand() {Connection = cn})
                {
                    cmd.CommandText = "SELECT CountryIdentifier, Name FROM dbo.Countries;";
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }

            return dt;
        }
        /// <summary>
        /// Get all Contact types for DataGridView ComboBox column
        /// </summary>
        /// <returns></returns>
        public static DataTable ContactTypeTable()
        {
            var dt = new DataTable();
            using (var cn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT ContactTypeIdentifier, ContactTitle  FROM dbo.ContactType;";
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }

            return dt;
        }


    }
}
