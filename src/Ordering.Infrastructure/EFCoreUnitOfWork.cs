using Ordering.Framework;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly OrderingContext _dbContext;

        public EFCoreUnitOfWork(OrderingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
