using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext _context;

        public OrderRepository(OrderingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public Task<Order> GetAsync(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
