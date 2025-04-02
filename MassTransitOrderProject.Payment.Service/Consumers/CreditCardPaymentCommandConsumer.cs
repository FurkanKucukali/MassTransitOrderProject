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

        public CreditCardPaymentCommandConsumer(ILogger<CreditCardPaymentCommandConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CreditCardPaymentCommand> context)
        {
            //Business Rules
            //Find the customer stored credit card
            // Get the payment 

            var customerId = context.Message.CustomerId;
            var orderId = context.Message.OrderId;
            var amount = context.Message.Amount;
            throw new NotImplementedException();
        }
    }
}
