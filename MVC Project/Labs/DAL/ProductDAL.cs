using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Labs.Models;


//data access layer to interact with products in the sql database
namespace Labs.DAL
{
    public class ProductDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProductDAL>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }
        public DbSet<Product> Products { get; set; }
    }
}