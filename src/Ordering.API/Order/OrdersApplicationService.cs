using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Framework;
using System.Linq;
using System.Threading.Tasks;
using OrderingAggregate = Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.Order
{
    public class OrdersApplicationService : IApplicationService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersApplicationService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
            command switch
            {
                Commands.V1.Create cmd =>
                    HandleCreate(cmd),
                _ => Task.CompletedTask
            };

        private async Task HandleCreate(Commands.V1.Create cmd)
        {
            //Create Value Object that is required for Entity from request.
            OrderingAggregate.Address address = new OrderingAggregate.Address(cmd.Street, cmd.City, cmd.State, cmd.Country, cmd.ZipCode);

            //Create Entity using Value Object.
            OrderingAggregate.Order order = new OrderingAggregate.Order(address);
            _orderRepository.Add(order);

            await _unitOfWork.Commit();
        }
    }
}
