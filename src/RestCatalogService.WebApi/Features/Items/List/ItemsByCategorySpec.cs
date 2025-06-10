using RestCatalogService.WebApi.Domain;
using System.Linq.Expressions;

namespace RestCatalogService.WebApi.Features.Items.List;

public class ItemsByCategorySpec : ISpecification<Item>
{
    public ItemsByCategorySpec(Guid? categoryId)
    {
        Criteria = categoryId.HasValue
            ? item => item.ItemCategories.Any(ic => ic.CategoryId == categoryId.Value)
            : item => true;
    }

    public Expression<Func<Item, bool>> Criteria { get; }
}
