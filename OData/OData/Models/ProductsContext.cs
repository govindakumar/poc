using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OData.Models
{
    public class ProductsContext: DbContext
    {
        public ProductsContext():base("name=ProductsDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsContext, 
                Migrations.Configuration>("ProductsDbConnection"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Products>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Products>()
                .Property(p => p.Category)
                .IsRequired();

            modelBuilder.Entity<Supplier>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Products>()
                .HasRequired(s => s.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.SupplierId);
        }
        public DbSet<Products> Products { get; set;}
        public DbSet<Supplier> Suppliers { get; set;}

    }
}