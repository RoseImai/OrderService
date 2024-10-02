using Microsoft.AspNetCore.Mvc;
using OrderBack.Interfaces;
using OrderBack.Models;

namespace OrderBack.Controllers;

[Route("[controller]")]
[ApiController]
public class NewOrdersController : Controller
{
    private readonly IOrderService _orderService;

    public NewOrdersController(IOrderService orderService)
    {
        _orderService = orderService;
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
    public IActionResult AddOrder(AddOrderDto addOrderDto)
    {
        var newOrder = _orderService.AddOrder(addOrderDto);
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