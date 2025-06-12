namespace RestCatalogService.WebApi.Domain;

public class Item
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public IList<ItemCategory> ItemCategories { get; private set; }

    public Item(string name, IList<Guid> categoriesIds) : this(Guid.NewGuid(), name, categoriesIds)
    {
    }

    public Item(Guid id, string name, IList<Guid> categoriesIds)
    {
        ValidateName(name);
        Name = name;

        ValidateCategories(categoriesIds);
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

    public void Update(string name, IList<Guid> categoryIds)
    {
        ValidateName(name);
        Name = name;

        ValidateCategories(categoryIds);
        ItemCategories = categoryIds.Select(cid => new ItemCategory { ItemId = Id, CategoryId = cid }).ToList();
    }

    private void ValidateCategories(IList<Guid> categoryIds)
    {
        ArgumentNullException.ThrowIfNull(categoryIds);

        if (categoryIds.Count == 0)
        {
            throw new ArgumentException("Must have at least one category", nameof(categoryIds));
        }

        if (categoryIds.Count != categoryIds.Distinct().Count())
        {
            throw new ArgumentException("All categories should be distinct");
        }
    }
}
