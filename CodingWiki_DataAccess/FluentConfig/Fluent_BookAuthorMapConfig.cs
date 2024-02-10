using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class Fluent_BookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(u => new { u.Book_Id, u.Author_Id });
            modelBuilder.HasOne(b => b.Book).WithMany(b => b.BookAuthorMap)
                .HasForeignKey(b => b.Book_Id);
            modelBuilder.HasOne(b => b.Author).WithMany(b => b.BookAuthorMap)
                .HasForeignKey(b => b.Author_Id);
        }
    }
}
