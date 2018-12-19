using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Labs.Models;


//data access layer to interact with admins in the sql database
namespace Labs.DAL
{
    public class AdminDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }
        public DbSet<Admin> Admins { get; set; }
    }
}