using DeliveryService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers;


[Route("[controller]")]
[ApiController]
public class DeliveryController : Controller
{
    private readonly IDeliveryService _deliveryService;

    public DeliveryController(IDeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    [HttpGet]
    public IActionResult GetAllDelivery()
    {
        var allDelivery = _deliveryService.GetAllDelivery();
        return Ok(allDelivery);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetDeliveryById(Guid id)
    {
        var delivery = _deliveryService.GetDeliveryById(id);
        if (delivery is null) return NotFound();

        return Ok(delivery);
    }
}