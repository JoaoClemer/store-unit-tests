using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}