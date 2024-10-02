using Microsoft.AspNetCore.Mvc;
using OrderBack.Data;
using OrderBack.Models;

namespace OrderBack.Сontrollers;

[Route("[controller]")]
[ApiController]
public class NewOrdersController : Controller
{
    private readonly OrderContext _orderContext;
    
    public NewOrdersController(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }
    
    //Метод для получения всех заказов
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var allOrders = _orderContext.Orders.ToList();
        return Ok(allOrders);
    }

    //Метод для получения заказа по id
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    //Метод для добавления новго заказа
    [HttpPost]
    public IActionResult AddOrder(AddOrderDto addOrderDto)
    {
        var orderEntity = new Order()
        {
            Name = addOrderDto.Name,
            Quantity = addOrderDto.Quantity
        };

        _orderContext.Orders.Add(orderEntity);
        _orderContext.SaveChanges();

        return Ok(orderEntity);
    }

    //Метод для изменения нового заказа
    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateOrder(Guid id, UpdateOrderDto updateOrderDto)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null)
        {
            return NotFound();
        }

        order.Name = updateOrderDto.Name;
        order.Quantity = updateOrderDto.Quantity;

        _orderContext.SaveChanges();

        return Ok(order);
    }

    //Метод удаления
    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteOrder(Guid id)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null)
        {
            return NotFound();
        }

        _orderContext.Orders.Remove(order);
        _orderContext.SaveChanges();

        return Ok("Deleted successful");
    }
}