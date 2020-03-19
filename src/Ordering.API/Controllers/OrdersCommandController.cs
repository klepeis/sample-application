using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersCommandController : ControllerBase
    {
        private readonly OrdersApplicationService _applicationService;

        public OrdersCommandController(OrdersApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// API to create a new Order.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Contracts.Orders.V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}