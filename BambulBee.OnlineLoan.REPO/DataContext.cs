﻿using BumbleBee.OnlineLoan.REPOSITORY.Models;
using Microsoft.EntityFrameworkCore;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LT-PE4-29\\SQLEXPRESS; initial catalog=BumbleBeeOnlineLoan;persist security info=True;TrustServerCertificate=True;user id=sa;password=#compaq123;");
        }
        public DbSet<Customer> Student { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Function> Function { get; set; }

        public virtual DbSet<UserFunctionAllocation> UserFunctionAllocation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(o => new { o.CustomerId });
            modelBuilder.Entity<Product>().HasKey(o => new { o.ProductId,o.CustomerId });
            modelBuilder.Entity<Category>().HasKey(o => new { o.CategoryId });
            modelBuilder.Entity<UserFunctionAllocation>()
           .HasKey(o => new { o.UserID, o.FunctionID });
        }
    }
}
