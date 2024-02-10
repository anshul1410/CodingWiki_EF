using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        //[Key]
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }


        public DbSet<Fluent_BookDetail> BookDetails_Fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, LogLevel.Information );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookAuthorMapConfig());



            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Wing of Fire", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Hounds of Baskerville", ISBN = "143B12", Price = 11.99m, Publisher_Id= 2 }
                
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1,CategoryName = "CAT1"},
                new Category { CategoryId = 2,CategoryName = "CAT2"},
                new Category { CategoryId = 3, CategoryName = "CAT3" }
                );

            var booklist = new Book[]
            {
                new Book { BookId = 3, Title = "Spiderman", ISBN = "145B12", Price = 9.99m, Publisher_Id= 3 },
                new Book { BookId = 4, Title = "Lord of rings", ISBN = "156B12", Price = 15.99m , Publisher_Id = 1}
            };

            modelBuilder.Entity<Book>().HasData(booklist);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "ABC", Location = "Delhi" },
                new Publisher { Publisher_Id = 2, Name = "DEF", Location = "New York"},
                new Publisher { Publisher_Id = 3, Name = "LDNCN", Location = "London" }
                );

            modelBuilder.Entity<BookAuthorMap>().HasKey(x => new { x.Book_Id, x.Author_Id });

            
        }
    }
}
