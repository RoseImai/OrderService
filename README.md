# OrderService
 Order Service made by .net core for internship's task


 # Docker
Добавлен docker-compose. Для запуска в фоновом режиме: docker-compose up -d

Для выключения: docker-compose down


# OrderBack (Backend)
Основной Route для проекта: "localhost:5247/neworders"

Для использования Swagger: "/swagger"

Для запуска в режиме разработки: dotnet run --environment Development

Фронтэнда у проекта нет. 
Все CRUD методы проверял через Postman, имеется возможность делать это через swagger.
Get методы (весь список или только один) можно посмотреть без фронтэнда по указанному url выше.

# Ocelot Gateway
Route для методов Get, Post: "/gateway/neworders"

Route для методов Get, Put, Delete по Id: "/gateway/neworders/{id}"

Примечание: Порты были изменены под запуск http

# DeliveryService
Основной url проекта: "localhost:5021/delivery"

Для использования Swagger: "/swagger"

Для запуска в режиме разработки: dotnet run --environment Development
