using Microsoft.AspNetCore.Mvc;
using Ordering.Infrastructure;

namespace Ordering.API.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderQueryApi : ControllerBase
    {
        private readonly OrdersApplicationService _applicationService;

        public OrderQueryApi()
        {
           
        }

        
    }
}