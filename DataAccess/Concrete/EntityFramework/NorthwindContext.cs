using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    //Db tablolari ile classlari baglamak
    public class NorthwindContext : DbContext
    {
        // Bu metod projenin hangi veri tabani ile iliskili oldugunu belirtecegimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=true;");
            //connection string ile ilgili bir hata alindi (Keyword not supported: 'server') Yazim formati ile ilgili bir unhandled hata!!!
        }

        public DbSet<Product> Products { get; set; }
        //Hangi class hangi tabloya denk geliyor bunu belirledik.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
