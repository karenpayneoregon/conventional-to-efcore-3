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
        private static string ConnectionString =
            "Data Source=.\\SQLEXPRESS;" +
            "Initial Catalog=NorthWindAzureForInserts;" +
            "Integrated Security=True";

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
                            "INNER JOIN Countries ON cust.CountryIdentifier = Countries.CountryIdentifier";

                        await cn.OpenAsync();
                        dataTable.Load(await cmd.ExecuteReaderAsync());
                    }
                }

            });

            return dataTable;
        }

    }
}
