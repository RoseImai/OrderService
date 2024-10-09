using Microsoft.EntityFrameworkCore;
using OrderBack.Data;
using OrderBack.Interfaces;
using OrderBack.Services;

var builder = WebApplication.CreateBuilder(args);

//Это запускает api через Kestrel (Настройки в appsettings.json)
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Configure(context.Configuration.GetSection("Kestrel"));
});

//Это добавляет Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Это добавляет поддержку контроллеров
builder.Services.AddControllers(); 

// Это добавляет сервис и его интерфейс
builder.Services.AddScoped<IOrderService, OrderService>();

//Это добавляет Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Добавление DbContext для работы с базой данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

//Это для включения Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Настройка маршрутизации и эндпоинтов
app.MapControllers();

app.Run();
