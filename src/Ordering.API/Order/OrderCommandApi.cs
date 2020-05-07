using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ordering.API.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderCommandApi : ControllerBase
    {
        private readonly OrdersApplicationService _applicationService;

        public OrderCommandApi(OrdersApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// API to create a new Order.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Commands.V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("I worked!");
        }
    }
}