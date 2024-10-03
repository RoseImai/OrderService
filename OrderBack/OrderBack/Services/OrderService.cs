using OrderBack.Data;
using OrderBack.Interfaces;
using OrderBack.Models;
using OrderBack.Models.Entities;

namespace OrderBack.Services;


public class OrderService : IOrderService
{
    private readonly OrderContext _orderContext;

    public OrderService(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public IEnumerable<OrderResponseDto> GetAllOrders()
    {
        var orders = _orderContext.Orders.ToList();
        
        return orders.Select(order => new OrderResponseDto
        {
            Name = order.Name,
            Quantity = order.Quantity
        });
    }

    public OrderResponseDto? GetOrderById(Guid id)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return null;

        return new OrderResponseDto
        {
            Name = order.Name,
            Quantity = order.Quantity
        };
    }

    public OrderResponseDto AddOrder(AddOrderDto newOrder)
    {
        var order = new Order
        {
            Name = newOrder.Name,
            Quantity = newOrder.Quantity
        };

        _orderContext.Orders.Add(order);
        _orderContext.SaveChanges();

        return new OrderResponseDto
        {
            Name = order.Name,
            Quantity = order.Quantity
        };
    }

    public OrderResponseDto? UpdateOrder(Guid id, UpdateOrderDto updateOrder)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return null;

        order.Name = updateOrder.Name;
        order.Quantity = updateOrder.Quantity;

        _orderContext.SaveChanges();

        return new OrderResponseDto
        {
            Name = order.Name,
            Quantity = order.Quantity
        };
    }

    public bool DeleteOrder(Guid id)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return false;

        _orderContext.Orders.Remove(order);
        _orderContext.SaveChanges();

        return true;
    }
}
