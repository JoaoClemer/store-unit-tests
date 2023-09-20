using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}