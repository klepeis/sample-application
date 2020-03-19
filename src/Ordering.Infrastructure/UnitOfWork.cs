using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Framework;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingContext _context;
        
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(OrderingContext context, IOrderRepository orderRepository)
        {
            _context = context;
            Orders = orderRepository;
        }

        public Task Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
