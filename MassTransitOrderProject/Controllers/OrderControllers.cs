using MassTransit;
using MassTransitOrderProject.API.Models;
using MassTransitOrderProject.Shared.Models.Payment.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitOrderProject.API.Controllers
{
    [Route("api/v1/order")]
    public class OrderControllers : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ILogger<OrderControllers> _logger;

        public OrderControllers(IBus bus,ILogger<OrderControllers> logger) 
        {
            _bus = bus;
            _logger  = logger;

        }

        [HttpPost]
        public async Task<AcceptedResult> CreateOrder ([FromBody] CreateOrder order)
        {
            var orderId = Guid.NewGuid();
            var customerId = order.customerID;
            var amount = order.Products.Sum(p => p.Quantity * p.Price);

            _logger.LogInformation(message: "Order accepted {orderId}",orderId);
           await  _bus.Publish<CreditCardPaymentCommand>(message:new CreditCardPaymentCommand(customerId,amount,orderId));

            return Accepted();
        }
    }
}
