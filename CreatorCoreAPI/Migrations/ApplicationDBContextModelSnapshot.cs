﻿// <auto-generated />
using System;
using CreatorCoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreatorCoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreatorCoreAPI.Models.Client", b =>
                {
                    b.Property<int>("clientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clientID"));

                    b.HasKey("clientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CreatorCoreAPI.Models.Creator", b =>
                {
                    b.Property<int>("creatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("creatorID"));

                    b.Property<string>("creatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("creatorRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("creatorRevenueSplit")
                        .HasColumnType("real");

                    b.Property<long>("lifeTimeEarnings")
                        .HasColumnType("bigint");

                    b.HasKey("creatorID");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("CreatorCoreAPI.Models.Transaction", b =>
                {
                    b.Property<int>("transactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transactionID"));

                    b.Property<int?>("clientID")
                        .HasColumnType("int");

                    b.Property<int?>("creatorID")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("transactionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("transactionValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("transactionID");

                    b.HasIndex("clientID");

                    b.HasIndex("creatorID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CreatorCoreAPI.Models.Transaction", b =>
                {
                    b.HasOne("CreatorCoreAPI.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientID");

                    b.HasOne("CreatorCoreAPI.Models.Creator", "creator")
                        .WithMany("transactions")
                        .HasForeignKey("creatorID");

                    b.Navigation("client");

                    b.Navigation("creator");
                });

            modelBuilder.Entity("CreatorCoreAPI.Models.Creator", b =>
                {
                    b.Navigation("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
