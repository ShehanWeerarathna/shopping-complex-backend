using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
        public DbSet<MaintenanceContract> MaintenanceContracts { get; set; }
        public DbSet<LeasePayment> LeasePayments { get; set; }
        public DbSet<MaintenancePayment> MaintenancePayments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

            // Add initial data to the Category table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beauty" },
                new Category { CategoryId = 2, CategoryName = "Book & Stationery" },
                new Category { CategoryId = 3, CategoryName = "Children’s Products" },
                new Category { CategoryId = 4, CategoryName = "Food & Drink" },
                new Category { CategoryId = 5, CategoryName = "Homeware" },
                new Category { CategoryId = 6, CategoryName = "Jewellery & Watches" },
                new Category { CategoryId = 7, CategoryName = "Men’s & Women’s Shoes" },
                new Category { CategoryId = 8, CategoryName = "Technology" }
            );
            // Configure relationships
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Stores)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Store>()
                .HasOne(s => s.LeaseAgreement)
                .WithOne(la => la.Store)
                .HasForeignKey<Store>(s => s.LeaseAgreementId)
                .OnDelete(DeleteBehavior.SetNull); // Allow Store to exist without LeaseAgreement

            modelBuilder.Entity<Store>()
                .HasOne(s => s.MaintenanceContract)
                .WithOne(mc => mc.Store)
                .HasForeignKey<Store>(s => s.MaintenanceContractId)
                .OnDelete(DeleteBehavior.SetNull); // Allow Store to exist without MaintenanceContract

            modelBuilder.Entity<LeaseAgreement>()
                .HasMany(la => la.LeasePayments)
                .WithOne(lp => lp.LeaseAgreement)
                .HasForeignKey(lp => lp.LeaseAgreementId);

            modelBuilder.Entity<MaintenanceContract>()
                .HasMany(mc => mc.MaintenancePayments)
                .WithOne(mp => mp.MaintenanceContract)
                .HasForeignKey(mp => mp.MaintenanceContractId);

            // Configure primary keys
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Store>().HasKey(s => s.StoreId);
            modelBuilder.Entity<LeaseAgreement>().HasKey(la => la.LeaseAgreementId);
            modelBuilder.Entity<MaintenanceContract>().HasKey(mc => mc.MaintenanceContractId);
            modelBuilder.Entity<LeasePayment>().HasKey(lp => lp.LeasePaymentId);
            modelBuilder.Entity<MaintenancePayment>().HasKey(mp => mp.MaintenancePaymentId);

        }
    }
}
