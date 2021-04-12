using DataOperationsEntityFrameworkNet5Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataOperationsEntityFrameworkNet5Core.Contexts
{
    public partial class NorthWindContext : DbContext
    {
        public NorthWindContext()
        {
        }

        public NorthWindContext(DbContextOptions<NorthWindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                 * Since the conventional code sample has the connection
                 * string in code the same is done here.
                 * See the following for storing connection string in app.config
                 * https://social.technet.microsoft.com/wiki/contents/articles/53869.entity-framework-core-3-x-database-connection.aspx
                 */
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWindAzureForInserts;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerIdentifier)
                    .HasName("PK_Customers_1");

                entity.Property(e => e.CustomerIdentifier).HasComment("Id");

                entity.Property(e => e.CompanyName).HasComment("Company");

                entity.Property(e => e.ContactId).HasComment("ContactId");

                entity.Property(e => e.ContactName).HasComment("Contact");

                entity.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

                entity.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Customers_Contacts");

                entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactTypeIdentifier)
                    .HasConstraintName("FK_Customers_ContactType");

                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Customers_Countries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}