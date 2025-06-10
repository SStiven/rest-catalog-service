using System.Linq.Expressions;

namespace RestCatalogService.WebApi.Features.Items.List;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
}
