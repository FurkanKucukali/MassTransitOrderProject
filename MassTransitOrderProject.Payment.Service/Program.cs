using CodeApp.Masstransit.Shared.Extensions;
using CodeApp.Masstransit.Shared.Models.Payment.Events;
using CodeApp.Masstransit.Shared.Settings;
using MassTransit;
using MassTransit.Configuration;
using MassTransitOrderProject.Payment.Service;
using MassTransitOrderProject.Payment.Service.Consumers;
using MassTransitOrderProject.Shared.Models.Payment.Commands;
using Microsoft.Extensions.Options;


var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

builder.Services.Configure<MassTransitSettings>(builder.Configuration.GetSection(key: "MassTransitSettings"));
builder.Services.AddMassTransit(x =>
{
    
    x.RegisterConsumer<CreditCardPaymentCommandConsumer>();
    x.UsingRabbitMq(configure: (context, cfg) =>
    {
        var massTransitSettings = context.GetRequiredService<IOptions<MassTransitSettings>>().Value;
        cfg.Host(massTransitSettings.Host, massTransitSettings.VirtualHost, configure: host =>
        {
            host.Username(massTransitSettings.Username);
            host.Password(massTransitSettings.Password);
        });

        cfg.RegisterQueue<CreditCardPaymentCommandConsumer>(context,massTransitSettings.QueueName, typeof(CreditCardPaymentCommand));

    });


});

var host = builder.Build();
host.Run();
