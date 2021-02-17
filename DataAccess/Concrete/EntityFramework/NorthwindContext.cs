using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //veri tabanı ile kendi classlarımızı ilişkilendirdiğimiz class
    //Context : Db tabloları ile proje classlarını bağlamak
    //on configuring : proje hangi veri tabanıyla ilişkili olduğunu belirten yer
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Northwind;Trusted_Connection=true");

        }
        //hangi tabloya ne karşılık gelecek örn: Product tablosu products a karşılık gelecek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
