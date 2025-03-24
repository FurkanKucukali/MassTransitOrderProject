using CodeApp.Masstransit.Shared.Settings;
using MassTransit;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.Configure<MassTransitSettings>(builder.Configuration.GetSection(key: "MassTransitSettings"));
builder.Services.AddMassTransit (x  =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
