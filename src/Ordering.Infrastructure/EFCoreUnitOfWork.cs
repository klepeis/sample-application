using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Framework;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly OrderingContext _context;

        public EFCoreUnitOfWork(OrderingContext context)
        {
            _context = context;
        }

        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
