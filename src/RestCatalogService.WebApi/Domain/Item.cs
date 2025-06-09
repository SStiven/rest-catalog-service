namespace RestCatalogService.WebApi.Domain;

public class Item
{
    public Guid Id { get; }
    public string Name { get; }
    public IList<ItemCategory> ItemCategories { get; private set; }

    public Item(string name, IList<Guid> categoriesIds) : this(Guid.NewGuid(), name, categoriesIds)
    {
    }

    public Item(Guid id, string name, IList<Guid> categoriesIds)
    {
        ValidateName(name);
        Name = name;

        if (categoriesIds.Count() == 0)
        {
            throw new ArgumentException("Must have at least one category", nameof(categoriesIds));
        }

        ItemCategories = categoriesIds.Select(cid => new ItemCategory { ItemId = id, CategoryId = cid }).ToList();
        Id = id;
    }

    private Item() { }

    private void ValidateName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        if (name.Length == 0)
        {
            throw new ArgumentException($"{nameof(name)} should have a value", nameof(name));
        }

        if (name.Length > 255)
        {
            throw new ArgumentException($"{nameof(name)} is too large", nameof(name));
        }
    }
}
