using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("item");

        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.Id)
            .IsUnique();

        builder.Property(i => i.Id)
            .HasColumnName("id");

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name");

        builder.HasMany(i => i.ItemCategories)
            .WithOne(ic => ic.Item)
            .HasForeignKey(ic => ic.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
