using System.Security.Cryptography.X509Certificates;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interaces;

namespace Store.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            
        }
    }
}