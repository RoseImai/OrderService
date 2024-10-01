using Microsoft.EntityFrameworkCore;
using OrderBack.Data;

var builder = WebApplication.CreateBuilder(args);

// Это добавляет поддержку контроллеров
builder.Services.AddControllers(); 

// Добавление DbContext для работы с базой данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Настройка маршрутизации и эндпоинтов
app.MapControllers();

app.Run();
