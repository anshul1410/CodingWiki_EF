﻿// <auto-generated />
using System;
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240207080002_MannualmappingErrorUpdate")]
    partial class MannualmappingErrorUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki_Models.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "123B12",
                            Price = 10.99m,
                            Publisher_Id = 1,
                            Title = "Wing of Fire"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "143B12",
                            Price = 11.99m,
                            Publisher_Id = 2,
                            Title = "Hounds of Baskerville"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "145B12",
                            Price = 9.99m,
                            Publisher_Id = 3,
                            Title = "Spiderman"
                        },
                        new
                        {
                            BookId = 4,
                            ISBN = "156B12",
                            Price = 15.99m,
                            Publisher_Id = 1,
                            Title = "Lord of rings"
                        });
                });

            modelBuilder.Entity("CodingWiki_Models.Models.BookAuthorMap", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.HasKey("Book_Id", "Author_Id");

                    b.HasIndex("Author_Id");

                    b.ToTable("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Publisher_Id = 1,
                            Location = "Delhi",
                            Name = "ABC"
                        },
                        new
                        {
                            Publisher_Id = 2,
                            Location = "New York",
                            Name = "DEF"
                        },
                        new
                        {
                            Publisher_Id = 3,
                            Location = "London",
                            Name = "LDNCN"
                        });
                });

            modelBuilder.Entity("CodingWiki_Models.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Book", b =>
                {
                    b.HasOne("CodingWiki_Models.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.BookAuthorMap", b =>
                {
                    b.HasOne("CodingWiki_Models.Models.Author", "Author")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingWiki_Models.Models.Book", "Book")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Models.Models.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("CodingWiki_Models.Models.BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Author", b =>
                {
                    b.Navigation("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Book", b =>
                {
                    b.Navigation("BookAuthorMap");

                    b.Navigation("BookDetail");
                });

            modelBuilder.Entity("CodingWiki_Models.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
