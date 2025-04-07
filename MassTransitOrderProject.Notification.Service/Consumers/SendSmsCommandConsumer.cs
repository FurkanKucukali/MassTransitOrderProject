using CodeApp.Masstransit.Shared.Models.Notification.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitOrderProject.Notification.Service.Consumers
{
    internal class SendSmsCommandConsumer : IConsumer<SendSmsCommand>
    {
        private readonly ILogger<SendSmsCommandConsumer> _logger;

        public SendSmsCommandConsumer(ILogger<SendSmsCommandConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SendSmsCommand> context)
        {
            _logger.LogInformation("Sent the SMS");

            return Task.CompletedTask;
            
        }
    }
}
