using CodeApp.Masstransit.Shared.Models.Payment.Events;
using MassTransit;
using MassTransitOrderProject.Shared.Models.Payment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitOrderProject.Payment.Service.Consumers
{
    public class CreditCardPaymentCommandConsumer : IConsumer<CreditCardPaymentCommand>
    {
        private readonly ILogger<CreditCardPaymentCommandConsumer> _logger;
        private readonly IBus _bus;
        public CreditCardPaymentCommandConsumer(IBus bus ,ILogger<CreditCardPaymentCommandConsumer> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreditCardPaymentCommand> context)
        {
            //Business Rules
            //Find the customer stored credit card
            // Get the payment 

            var customerId = context.Message.CustomerId;
            var orderId = context.Message.OrderId;
            var amount = context.Message.Amount;

            var cardNumber = "**** 1362";
            var paymentId = Guid.NewGuid();

            await _bus.Publish<OrderPaymentReceivedEvent>(message: new OrderPaymentReceivedEvent(
                CustomerId:customerId,Amount: amount,CardNumber:cardNumber,OrderId:orderId,PaymentNumberGuid:paymentId));

            _logger.LogInformation(message: "Payment received, OrderId: {orderId}, PaymentId: {paymentId}",orderId,paymentId);


            

          
        }
    }
}
