namespace RestCatalogService.WebApi.Domain;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; }

    public Category(string name) : this(Guid.NewGuid(), name)
    {
    }

    public Category(Guid id, string name)
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

        Name = name;
        Id = id;
    }
}
