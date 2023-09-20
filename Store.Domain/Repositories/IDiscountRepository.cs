using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interaces
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}