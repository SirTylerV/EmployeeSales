using EmployeeSales.Models.DB;
using EmployeeSales.Models.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Data
{
    public class EmployeeSalesDbContext : DbContext
    {
        public EmployeeSalesDbContext(DbContextOptions<EmployeeSalesDbContext> options) 
            : base(options) {}

        #region Tables
        public DbSet<Commission> Commission { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Store> Store { get; set; }
        #endregion Tables

        #region Procedure Models
        public DbSet<StoreListModel> StoreListModel { get; set; }
        #endregion Procedure Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Comimssion Building
            modelBuilder.Entity<Commission>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Commission>()
                .Property(c => c.Percent)
                .HasPrecision(2, 2)
                .IsRequired();
            modelBuilder.Entity<Commission>()
                .Property(c => c.ProfitEligibility)
                .HasPrecision(2, 2)
                .IsRequired();
            modelBuilder.Entity<Commission>()
                .HasMany(c => c.Purchases)
                .WithOne(p => p.Commission);

            // Employee Building
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasMaxLength(300)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasMaxLength(300)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.HireDate)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.StoreId)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmploymentStatusId)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Store)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.StoreId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmploymentStatus)
                .WithMany(es => es.Employees)
                .HasForeignKey(e => e.EmploymentStatusId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Sales)
                .WithOne(s => s.Employee);

            // EmploymentStatus
            modelBuilder.Entity<EmploymentStatus>()
                .HasKey(es => es.Id);
            modelBuilder.Entity<EmploymentStatus>()
                .Property(es => es.StatusName)
                .HasMaxLength(10)
                .IsRequired();
            modelBuilder.Entity<EmploymentStatus>()
                .HasMany(es => es.Employees)
                .WithOne(e => e.EmploymentStatus);

            // Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(500)
                .IsRequired();
            modelBuilder.Entity<Product>()
                 .Property(p => p.Description)
                 .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Wholesale)
                .HasPrecision(8,2)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Purchases)
                .WithOne(p => p.Product);

            // Purchase
            modelBuilder.Entity<Purchase>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Purchase>()
                .Property(p => p.EmployeeId)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .Property(p => p.ProductId)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .Property(p => p.CommissionId)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .Property(p => p.CreatedAt)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .Property(p => p.SalePrice)
                .HasPrecision(12, 2)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .Property(p => p.CommissionMade)
                .HasPrecision(10, 2)
                .IsRequired();
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Sales)
                .HasForeignKey(p => p.EmployeeId);
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Commission)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.CommissionId);
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Purchases)
                .HasForeignKey(p => p.ProductId);

            // Store
            modelBuilder.Entity<Store>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Store>()
                .Property(s => s.StoreName)
                .HasMaxLength(500)
                .IsRequired();
            modelBuilder.Entity<Store>()
                .Property(s => s.Street)
                .HasMaxLength(500)
                .IsRequired();
            modelBuilder.Entity<Store>()
                .Property(s => s.State)
                .IsRequired();
            modelBuilder.Entity<Store>()
                .Property(s => s.ZipCode)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
