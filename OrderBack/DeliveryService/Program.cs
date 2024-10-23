using System.Text.Json.Serialization;
using DeliveryService.Consumers;
using DeliveryService.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Это запускает api через Kestrel (Настройки в appsettings.json)
builder.WebHost.ConfigureKestrel(options =>
{
    options.Configure(builder.Configuration.GetSection("Kestrel"));
});

//Это добавляет Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Это для подключения к DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DeliveryContext>(options =>
    options.UseNpgsql(connectionString));

// MassTransit and RabbitMQ
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumer<OrderCreatedConsumer>();
    busConfigurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        
        cfg.ReceiveEndpoint("OrderCreatedQueue", e =>
        {
            e.Bind("order-created-exchange");
            e.ConfigureConsumer<OrderCreatedConsumer>(context);
            e.ConfigureConsumeTopology = false;
        });
        
        cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(false));
        LogContext.ConfigureCurrentLogContext();
    });
});

var app = builder.Build();

// Это для Swagger в Дев билде 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();