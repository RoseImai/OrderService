using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderBack.Interfaces;
using OrderBack.Messages;
using OrderBack.Models;

namespace OrderBack.Сontrollers;

[Route("[controller]")]
[ApiController]
public class NewOrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IPublishEndpoint _publishEndpoint;

    public NewOrdersController(IOrderService orderService, IPublishEndpoint publishEndpoint)
    {
        _orderService = orderService;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var allOrders = _orderService.GetAllOrders();
        return Ok(allOrders);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _orderService.GetOrderById(id);
        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody]AddOrderDto addOrderDto)
    {
        var newOrder = _orderService.AddOrder(addOrderDto);
        var orderCreatedEvent = new OrderCreated
        {
            Id = newOrder.Id,
            Name = newOrder.Name,
            Quantity = newOrder.Quantity
        };

        await _publishEndpoint.Publish(orderCreatedEvent);
        return Ok(newOrder);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateOrder(Guid id, UpdateOrderDto updateOrderDto)
    {
        var updatedOrder = _orderService.UpdateOrder(id, updateOrderDto);
        if (updatedOrder is null)
        {
            return NotFound();
        }

        return Ok(updatedOrder);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteOrder(Guid id)
    {
        var deleted = _orderService.DeleteOrder(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok("Deleted successfully");
    }
}