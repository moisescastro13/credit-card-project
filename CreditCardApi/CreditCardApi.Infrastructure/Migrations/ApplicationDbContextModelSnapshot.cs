﻿// <auto-generated />
using System;
using CreditCardApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCard", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreditCardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CutOffDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCardDetails", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreditCarID")
                        .HasColumnType("bigint");

                    b.Property<int>("CreditCardType")
                        .HasColumnType("int");

                    b.Property<double>("CurrentInterest")
                        .HasColumnType("float");

                    b.Property<double>("Currentbalance")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreditCarID")
                        .IsUnique();

                    b.ToTable("CreditCardDetails");
                });

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCardTransaction", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreditCardID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardID");

                    b.ToTable("CreditCardTransactions");
                });

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCardDetails", b =>
                {
                    b.HasOne("CreditCardApi.Domain.Entities.CreditCard", "CreditCard")
                        .WithOne("CreditCardDetails")
                        .HasForeignKey("CreditCardApi.Domain.Entities.CreditCardDetails", "CreditCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCard");
                });

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCardTransaction", b =>
                {
                    b.HasOne("CreditCardApi.Domain.Entities.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCard");
                });

            modelBuilder.Entity("CreditCardApi.Domain.Entities.CreditCard", b =>
                {
                    b.Navigation("CreditCardDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
