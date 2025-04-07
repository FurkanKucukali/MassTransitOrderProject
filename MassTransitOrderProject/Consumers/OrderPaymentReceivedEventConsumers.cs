using CodeApp.Masstransit.Shared.Models.Payment.Events;
using MassTransit;

namespace MassTransitOrderProject.API.Consumers
{
    public class OrderPaymentReceivedEventConsumers : IConsumer<OrderPaymentReceivedEvent>
    {
        private readonly ILogger<OrderPaymentReceivedEventConsumers> _logger;

        public OrderPaymentReceivedEventConsumers(ILogger<OrderPaymentReceivedEventConsumers> logger)
        {
            _logger = logger;
            
        }
        public Task Consume(ConsumeContext<OrderPaymentReceivedEvent> context)
        {

            var orderId = context.Message.OrderId;
            var customerId = context.Message.CustomerId;
            _logger.LogInformation(message: "Order Payment Received,OrderId: {orderId}, customerId: {customerId}",orderId,customerId);
            return Task.CompletedTask;
        }
    }
}
