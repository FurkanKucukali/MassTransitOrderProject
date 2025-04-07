using CodeApp.Masstransit.Shared.Settings;
using MassTransit;
using Microsoft.Extensions.Options;



var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MassTransitSettings>(builder.Configuration.GetSection(key: "MassTransitSettings"));
builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq(configure: (context, cfg) =>
    {
        var massTransitSettings = context.GetRequiredService<IOptions<MassTransitSettings>>().Value;
        cfg.Host(massTransitSettings.Host, massTransitSettings.VirtualHost, configure: host =>
        {
            host.Username(massTransitSettings.Username);
            host.Password(massTransitSettings.Password);
        });

    });


});


var host = builder.Build();
host.Run();
