using Microsoft.EntityFrameworkCore;
using OrderBack.Data;
using OrderBack.Interfaces;
using OrderBack.Services;

var builder = WebApplication.CreateBuilder(args);

// Это добавляет поддержку контроллеров
builder.Services.AddControllers(); 

// Это добавляет сервис и его интерфейс
builder.Services.AddScoped<IOrderService, OrderService>();

// Добавление DbContext для работы с базой данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Настройка маршрутизации и эндпоинтов
app.MapControllers();

app.Run();
