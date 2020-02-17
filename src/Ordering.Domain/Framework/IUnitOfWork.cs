using System.Threading.Tasks;

namespace Ordering.Domain.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
