using CodeApp.Masstransit.Shared.Models.Notification.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitOrderProject.Notification.Service.Consumers
{
    internal class SendMailCommandConsumer : IConsumer<SendEmailCommand>
    {
        private readonly ILogger<SendMailCommandConsumer> _logger;

        public SendMailCommandConsumer(ILogger<SendMailCommandConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            _logger.LogInformation("Sent the Email");

            return Task.CompletedTask;

        }
    }
}
