using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Order;
using System.Threading.Tasks;

namespace Ordering.API.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderQueryApi : ControllerBase
    {
        private readonly OrdersQueryService _applicationService;

        public OrderQueryApi(OrdersQueryService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Get(QueryModels.GetOrderItem request)
        {
            // TODO: Look @ Request Handler.
            return Ok(await _applicationService.Query(request));
        }
    }
}