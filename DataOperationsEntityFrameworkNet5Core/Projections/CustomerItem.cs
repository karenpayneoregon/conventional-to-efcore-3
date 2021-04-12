using System;
using System.Linq.Expressions;
using DataOperationsEntityFrameworkNet5Core.Models;

namespace DataOperationsEntityFrameworkNet5Core.Projections
{
    public class CustomerItem
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ContactId { get; set; }
        public string ContactTitle { get; set; }
        public int? CountryIdentifier { get; set; }
        public string CountryName { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        /// <summary>
        /// Provides a convenient method to get required columns
        /// </summary>
        public static Expression<Func<Customers, CustomerItem>> Projection
        {
            get
            {
                return (customers) => new CustomerItem()
                {
                    CustomerIdentifier = customers.CustomerIdentifier,
                    CompanyName = customers.CompanyName,
                    ContactId = customers.ContactId,
                    ContactTitle = customers.ContactTypeIdentifierNavigation.ContactTitle,
                    FirstName = customers.Contact.FirstName,
                    LastName =  customers.Contact.LastName,
                    CountryIdentifier = customers.CountryIdentifier,
                    CountryName = customers.CountryIdentifierNavigation.Name,
                    ContactTypeIdentifier = customers.ContactTypeIdentifier
                };
            }
        }
    }
}