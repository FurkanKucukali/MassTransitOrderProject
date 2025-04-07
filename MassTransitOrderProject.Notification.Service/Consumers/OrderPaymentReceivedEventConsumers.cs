using CodeApp.Masstransit.Shared.Models.Notification.Commands;
using CodeApp.Masstransit.Shared.Models.Payment.Events;
using MassTransit;

namespace MassTransitOrderProject.Notification.Service.Consumers
{
    public class OrderPaymentReceivedEventConsumers : IConsumer<OrderPaymentReceivedEvent>
    {
        private readonly ILogger<OrderPaymentReceivedEventConsumers> _logger;
        private readonly IBus _bus;
        public OrderPaymentReceivedEventConsumers(IBus bus,ILogger<OrderPaymentReceivedEventConsumers> logger)
        {
            _logger = logger;
            _bus = bus;

        }
        public async Task Consume(ConsumeContext<OrderPaymentReceivedEvent> context)
        {

            var orderId = context.Message.OrderId;
            var customerId = context.Message.CustomerId;
            var amount = context.Message.Amount;
            var phoneNumber = "+12345 ***";
            var emailAddress = "ben@furkankucukali.com";
            var cardNumber = context.Message.CardNumber;
            var toMailAddress = new List<string>
            {
                "gonder@mail.com"
            };


            var content = $"Payment received for this order, OrderId: {orderId}, Payment Amount: {amount}, Card Number: {cardNumber}";
            await _bus.Publish<SendSmsCommand>(message: new SendSmsCommand(phoneNumber,content));
            await _bus.Publish<SendEmailCommand>(message: new SendEmailCommand(toMailAddress,"Payment Received",content));
            _logger.LogInformation(message: "Order Payment Received,OrderId: {orderId}, customerId: {customerId}", orderId, customerId);
            return Task.CompletedTask;
        }
    }
}
