using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataOperationsEntityFrameworkCore.Models
{
    public partial class Customers
    {
        [Key]
        public int CustomerIdentifier { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        public int? ContactId { get; set; }
        public int? CountryIdentifier { get; set; }
        public int? ContactTypeIdentifier { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty(nameof(Contacts.Customers))]
        public virtual Contacts Contact { get; set; }
        [ForeignKey(nameof(ContactTypeIdentifier))]
        [InverseProperty(nameof(ContactType.Customers))]
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        [ForeignKey(nameof(CountryIdentifier))]
        [InverseProperty(nameof(Countries.Customers))]
        public virtual Countries CountryIdentifierNavigation { get; set; }
    }
}