using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.ItemCategories;

public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("item_category");

        builder.HasKey(ic => new { ic.ItemId, ic.CategoryId });

        builder.Property(ic => ic.CategoryId)
            .HasColumnName("category_id");

        builder.Property(ic => ic.ItemId)
            .HasColumnName("item_id");

        builder.HasOne(ic => ic.Item)
            .WithMany(i => i.ItemCategories)
            .HasForeignKey(ic => ic.ItemId);

        builder.HasOne(ic => ic.Category)
            .WithMany(c => c.ItemCategories)
            .HasForeignKey(ic => ic.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
