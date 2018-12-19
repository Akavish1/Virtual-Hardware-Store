using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Labs.Models;


//data access layer to interact with customers in the sql database
namespace Labs.DAL
{
    public class CustomerDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CustomerDAL>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}