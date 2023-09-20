namespace Store.Domain.Repositories.Interaces
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipCode);
    }
}