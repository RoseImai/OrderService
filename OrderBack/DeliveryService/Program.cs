using DeliveryService.Consumers;
using DeliveryService.Data;
using DeliveryService.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Это добавляет поддержку контроллеров
builder.Services.AddControllers(); 

// Это добавляет сервис и его интерфейс
builder.Services.AddScoped<IDeliveryService, DeliveryService.Services.DeliveryService>();

//Это добавляет Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
        var rabbitMqSettings = builder.Configuration.GetSection("RabbitMq");
        var host = rabbitMqSettings["Host"];
        var username = rabbitMqSettings["Username"];
        var password = rabbitMqSettings["Password"];
        
        cfg.Host(host, h =>
        {
            h.Username(username);
            h.Password(password);
        });

        cfg.ReceiveEndpoint(
            nameof(OrderCreatedConsumer), e =>
            {
                e.PrefetchCount = 1000;
                e.Consumer<OrderCreatedConsumer>(context);
            });
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

app.MapControllers();

app.Run();