﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingComplex.Infrastructure.Data;

#nullable disable

namespace ShoppingComplex.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231113052808_MaintenanceContract")]
    partial class MaintenanceContract
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.LeaseAgreement", b =>
                {
                    b.Property<int>("LeaseAgreementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaseAgreementId"), 1L, 1);

                    b.Property<decimal>("LeaseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LeaseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("LeaseAgreementId");

                    b.ToTable("LeaseAgreements");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.LeasePayment", b =>
                {
                    b.Property<int>("LeasePaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeasePaymentId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LeaseAgreementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeasePaymentId");

                    b.HasIndex("LeaseAgreementId");

                    b.ToTable("LeasePayments");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.MaintenanceContract", b =>
                {
                    b.Property<int>("MaintenanceContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceContractId"), 1L, 1);

                    b.Property<decimal>("ContractAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("MaintenanceContractId");

                    b.ToTable("MaintenanceContracts");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.MaintenancePayment", b =>
                {
                    b.Property<int>("MaintenancePaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenancePaymentId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaintenanceContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MaintenancePaymentId");

                    b.HasIndex("MaintenanceContractId");

                    b.ToTable("MaintenancePayments");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("LeaseAgreementId")
                        .HasColumnType("int");

                    b.Property<int?>("MaintenanceContractId")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LeaseAgreementId")
                        .IsUnique()
                        .HasFilter("[LeaseAgreementId] IS NOT NULL");

                    b.HasIndex("MaintenanceContractId")
                        .IsUnique()
                        .HasFilter("[MaintenanceContractId] IS NOT NULL");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.LeasePayment", b =>
                {
                    b.HasOne("ShoppingComplex.Domain.Entities.LeaseAgreement", "LeaseAgreement")
                        .WithMany("LeasePayments")
                        .HasForeignKey("LeaseAgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaseAgreement");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.MaintenancePayment", b =>
                {
                    b.HasOne("ShoppingComplex.Domain.Entities.MaintenanceContract", "MaintenanceContract")
                        .WithMany("MaintenancePayments")
                        .HasForeignKey("MaintenanceContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceContract");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.Store", b =>
                {
                    b.HasOne("ShoppingComplex.Domain.Entities.Category", "Category")
                        .WithMany("Stores")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingComplex.Domain.Entities.LeaseAgreement", "LeaseAgreement")
                        .WithOne("Store")
                        .HasForeignKey("ShoppingComplex.Domain.Entities.Store", "LeaseAgreementId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ShoppingComplex.Domain.Entities.MaintenanceContract", "MaintenanceContract")
                        .WithOne("Store")
                        .HasForeignKey("ShoppingComplex.Domain.Entities.Store", "MaintenanceContractId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("LeaseAgreement");

                    b.Navigation("MaintenanceContract");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.Category", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.LeaseAgreement", b =>
                {
                    b.Navigation("LeasePayments");

                    b.Navigation("Store")
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingComplex.Domain.Entities.MaintenanceContract", b =>
                {
                    b.Navigation("MaintenancePayments");

                    b.Navigation("Store")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}