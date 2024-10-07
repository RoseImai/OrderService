using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Чтение конфигурации Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Добавление Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Использование Ocelot
await app.UseOcelot();

app.Run();