using Ordering.Domain.AggregatesModel;
using Ordering.Framework;
using System.Threading.Tasks;
using static Ordering.API.Contracts.Orders;

namespace Ordering.API
{
    public class OrdersApplicationService : IApplicationService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersApplicationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
            //TODO: Do we need this?
            //_orderRepository.Save();
            // Packt Page 178
        }
    }
}
