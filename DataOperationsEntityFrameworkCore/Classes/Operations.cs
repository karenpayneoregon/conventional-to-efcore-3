using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataOperationsEntityFrameworkCore.Contexts;
using DataOperationsEntityFrameworkCore.Projections;
using Microsoft.EntityFrameworkCore;

namespace DataOperationsEntityFrameworkCore.Classes
{
    public class Operations
    {
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {

            return await Task.Run(async () =>
            {

                using (var context = new NorthWindContext())
                {
                    return await context.Customers.AsNoTracking().Select(CustomerItem.Projection).ToListAsync();
                }

            });

        }

        public static List<string> CountryNameList()
        {
            using (var context = new NorthWindContext())
            {
                var countryNames = context.Countries.AsNoTracking().Select(country => country.Name).ToList();
                countryNames.Insert(0,"Remove filter");
                return countryNames;
            }
        }

    }
}
