namespace RestCatalogService.WebApi.Domain;

public class ItemCategory
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
