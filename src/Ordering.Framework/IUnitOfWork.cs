using System.Threading.Tasks;

namespace Ordering.Framework
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
