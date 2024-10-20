using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucutre.Data.Config
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b=>b.BookId);
            builder.Property(b=>b.Name).HasColumnName("Name").HasColumnType("VARCHAR");
            builder.Property(b=>b.Description).HasColumnName("Description").HasColumnType("VARCHAR");
            builder.Property(b=>b.Price).HasColumnName("Price").HasColumnType("decimal");
            builder.Property(b=>b.Stock).HasColumnName("Stock").HasColumnType("INT");
            builder.HasOne(b => b.Category).WithMany(b=>b.Books).HasForeignKey(b=>b.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
