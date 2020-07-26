using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataOperationsEntityFrameworkCore.Contexts;
using DataOperationsEntityFrameworkCore.Models;
using DataOperationsEntityFrameworkCore.Projections;
using Microsoft.EntityFrameworkCore;

namespace DataOperationsEntityFrameworkCore.Classes
{
    public class Operations
    {
        /// <summary>
        /// Get all customers ordered by company name using a projection
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {

            return await Task.Run(async () =>
            {

                using (var context = new NorthWindContext())
                {
                    return await context.Customers
                        .Include(customer => customer.ContactTypeIdentifierNavigation)
                        .AsNoTracking().Select(CustomerItem.Projection)
                        .OrderBy(customer => customer.CompanyName)
                        .ToListAsync();
                }

            });

        }

        /// <summary>
        /// Country names for filtering
        /// </summary>
        /// <returns></returns>
        public static List<string> CountryNameList()
        {
            using (var context = new NorthWindContext())
            {
                var countryNames = context.Countries.AsNoTracking().Select(country => country.Name).ToList();
                countryNames.Insert(0,"Remove filter");
                return countryNames;
            }
        }

        /// <summary>
        /// Get all Countries for DataGridView ComboBox column
        /// </summary>
        /// <returns></returns>
        public static List<Countries> Countries()
        {
            using (var context = new NorthWindContext())
            {
                return context.Countries.AsNoTracking().ToList();

            }
        }
        /// <summary>
        /// Get all Contact types for DataGridView ComboBox column
        /// </summary>
        /// <returns></returns>
        public static List<ContactType> ContactTypes()
        {
            using (var context = new NorthWindContext())
            {
                return context.ContactType.AsNoTracking().ToList();
            }
        }

    }
}
