using System.Threading.Tasks;

namespace Ordering.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
