using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name");
    }
}
