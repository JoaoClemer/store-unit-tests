using Store.Domain.Entities;
using Store.Domain.Repositories.Interaces;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if(document == "12345678911")
                return new Customer("João Clemer","joao@email.com");

            return null;
        }
    }
}