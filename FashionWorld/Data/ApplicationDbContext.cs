using System;
using System.Collections.Generic;
using System.Text;
using FashionWorld.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Market> Markets { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Favorites)
                .WithOne(bc => bc.Product)
                .IsRequired();

            modelBuilder.Entity<AppUser>()
                .HasMany(c => c.Favorites)
                .WithOne(bc => bc.AppUser)
                .IsRequired();


            base.OnModelCreating(modelBuilder);

        }
    }
}
