using CodeApp.Masstransit.Shared.Extensions;
using CodeApp.Masstransit.Shared.Models.Notification.Commands;
using CodeApp.Masstransit.Shared.Models.Payment.Events;
using CodeApp.Masstransit.Shared.Settings;
using MassTransit;
using MassTransit.Configuration;
using MassTransitOrderProject.Notification.Service.Consumers;
using MassTransitOrderProject.Payment.Service.Consumers;
using MassTransitOrderProject.Shared.Models.Payment.Commands;
using Microsoft.Extensions.Options;



var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MassTransitSettings>(builder.Configuration.GetSection(key: "MassTransitSettings"));
builder.Services.AddMassTransit(x =>
{
    x.RegisterConsumer<OrderPaymentReceivedEventConsumers>();
    x.RegisterConsumer<SendMailCommandConsumer>();
    x.RegisterConsumer<SendSmsCommandConsumer>();

    x.UsingRabbitMq(configure: (context, cfg) =>
    {
        var massTransitSettings = context.GetRequiredService<IOptions<MassTransitSettings>>().Value;
        cfg.Host(massTransitSettings.Host, massTransitSettings.VirtualHost, configure: host =>
        {
            host.Username(massTransitSettings.Username);
            host.Password(massTransitSettings.Password);
        });
        
        cfg.RegisterQueue<OrderPaymentReceivedEventConsumers>(context, massTransitSettings.QueueName, typeof(OrderPaymentReceivedEvent));
        cfg.RegisterQueue<SendMailCommandConsumer>(context, massTransitSettings.QueueName, typeof(SendEmailCommand));
        cfg.RegisterQueue<SendSmsCommandConsumer>(context, massTransitSettings.QueueName, typeof(SendSmsCommand));


    });


});


var host = builder.Build();
host.Run();
