# OrderService
 Order Service made by .net core for internship's task


# OrderBack (Backend)
Основной Route для проекта: "localhost:xxxx/neworders"

Фронтэнда у проекта нет. 
Все CRUD методы проверял через Postman.
Get методы (весь список или только один) можно посмотреть без фронтэнда по указанному url выше.

# Ocelot Gateway
Route для методов Get, Post: "/gateway/neworders"

Route для методов Get, Put, Delete по Id: "/gateway/neworders/{id}"

Примечание: Порты были изменены под запуск http
