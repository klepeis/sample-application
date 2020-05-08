using Ordering.Infrastructure;
using System.Threading.Tasks;
using static Ordering.Application.Order.ReadModels;

namespace Ordering.Application.Order
{
    public class OrdersQueryService
    {
        private readonly OrderingContext _orderingContext;

        public OrdersQueryService(OrderingContext orderingContext)
        {
            _orderingContext = orderingContext;
        }

        public async Task<OrderItem> Query(QueryModels.GetOrderItem query)
        {
            //Is it a problem that the Aggregate is returned?  Since we are using EF for both read 
            //and command same Data Models are used
            //This might handle the "Fund Name" scenario.


            var queryResult = await _orderingContext.OrderItems.FindAsync(query.OrderItemId);

            OrderItem returnValue = new OrderItem
            {
                Id = queryResult.Id,
                PictureUrl = queryResult.GetPictureUri(),
                ProductName = queryResult.GetOrderItemProductName(),
                UnitPrice = queryResult.GetUnitPrice()
            };

            return returnValue;
        }
    }
}
