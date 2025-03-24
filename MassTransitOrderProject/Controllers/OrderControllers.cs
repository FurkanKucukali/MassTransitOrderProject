using MassTransitOrderProject.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitOrderProject.API.Controllers
{
    [Route("api/v1/order")]
    public class OrderControllers : ControllerBase
    {

        [HttpPost]
        public AcceptedResult CreateOrder ([FromBody] CreateOrder order)
        {
            return Accepted();
        }
    }
}
