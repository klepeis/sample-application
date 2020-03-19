using Ordering.Framework;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregatesModel.OrderAggregate
{
    /// <summary>
    /// This is the Repository Contact defined at the Domain Laster is requisite for the Order Aggregate
    /// </summary>
    public interface IOrderRepository
    {
        Order Add(Order order);
        void Update(Order order);
        Task<Order> GetAsync(int orderId);
    }
}
