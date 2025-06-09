namespace RestCatalogService.WebApi.Domain;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Category(string name) : this(Guid.NewGuid(), name)
    {
    }

    public Category(Guid id, string name)
    {
        ValidateName(name);

        Name = name;
        Id = id;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);

        Name = name;
    }

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
