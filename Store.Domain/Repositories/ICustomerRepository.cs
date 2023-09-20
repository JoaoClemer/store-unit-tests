using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interaces
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}