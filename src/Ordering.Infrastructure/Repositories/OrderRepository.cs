using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {    

        public OrderRepository(OrderingContext context)
            :base(context)
        {
        }
    }
}
