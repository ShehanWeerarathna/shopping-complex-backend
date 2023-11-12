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
        public DbSet<LeasePayment> LeasePayments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<LeaseAgreement>()
                .HasMany(la => la.LeasePayments)
                .WithOne(lp => lp.LeaseAgreement)
                .HasForeignKey(lp => lp.LeaseAgreementId);

            // Configure primary keys
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Store>().HasKey(s => s.StoreId);
            modelBuilder.Entity<LeaseAgreement>().HasKey(la => la.LeaseAgreementId);
            modelBuilder.Entity<LeasePayment>().HasKey(lp => lp.LeasePaymentId);

        }
    }
}
