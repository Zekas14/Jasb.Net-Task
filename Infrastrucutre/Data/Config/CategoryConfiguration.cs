using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastrucutre.Data.Config
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(b => b.CategoryId);
            builder.Property(b => b.Name).HasColumnName("Name").HasColumnType("VARCHAR");
            builder.Property(b => b.Description).HasColumnName("Description").HasColumnType("VARCHAR");
        }
    }
}
