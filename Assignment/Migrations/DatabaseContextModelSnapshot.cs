﻿// <auto-generated />
using System;
using Assignment.DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LoginID")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NationalIDNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<Guid?>("RowGuid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Assignment.Models.ProductCategoryModel", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Discription");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Assignment.Models.ProductModel", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("ProductId");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("CategoryId");

                    b.Property<string>("ProductDiscription")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ProductDiscription");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ProductName");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ProductPrice");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int")
                        .HasColumnName("ProductQuantity");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Assignment.Models.UserInfo", b =>
                {
                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("Assignment.Models.ProductModel", b =>
                {
                    b.HasOne("Assignment.Models.ProductCategoryModel", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Assignment.Models.ProductCategoryModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
