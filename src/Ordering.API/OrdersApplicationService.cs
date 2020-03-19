using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Framework;
using System.Threading.Tasks;
using static Ordering.API.Contracts.Orders;

namespace Ordering.API
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
                V1.Create cmd =>
                    HandleCreate(cmd),
                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.Create cmd)
        {
            //Create Value Object that is required for Entity from request.
            Address address = new Address(cmd.Street, cmd.City, cmd.State, cmd.Country, cmd.ZipCode);

            //Create Entity using Value Object.
            Order order = new Order(address);

            _orderRepository.Add(order);

            await _unitOfWork.Commit();
        }
    }
}
