# OrderService
 Order Service made by .net core for internship's task


 # Docker
Добавлен docker-compose. Для запуска: docker-compose up -d

Для выключения: docker-compose down


# OrderBack (Backend)
Основной Route для проекта: "localhost:xxxx/neworders"

Для использования Swagger: "/swagger"

Для запуска в режиме разработки: dotnet run --environment Development

Фронтэнда у проекта нет. 
Все CRUD методы проверял через Postman.
Get методы (весь список или только один) можно посмотреть без фронтэнда по указанному url выше.

# Ocelot Gateway
Route для методов Get, Post: "/gateway/neworders"

Route для методов Get, Put, Delete по Id: "/gateway/neworders/{id}"

Примечание: Порты были изменены под запуск http
