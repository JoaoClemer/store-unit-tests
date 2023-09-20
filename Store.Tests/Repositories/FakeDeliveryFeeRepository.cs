using Store.Domain.Repositories.Interaces;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}