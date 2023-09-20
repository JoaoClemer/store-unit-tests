using Store.Domain.Entities;
using Store.Domain.Repositories.Interaces;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            var products = new List<Product>();
            products.Add(new Product("Product 01", 10, true));
            products.Add(new Product("Product 02", 10, true));
            products.Add(new Product("Product 03", 10, true));
            products.Add(new Product("Product 04", 10, false));
            products.Add(new Product("Product 05", 10, false));

            return products;
        }
    }
}