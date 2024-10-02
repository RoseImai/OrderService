using Microsoft.AspNetCore.Http.HttpResults;
using OrderBack.Data;
using OrderBack.Interfaces;
using OrderBack.Models;

namespace OrderBack.Services;


public class OrderService : IOrderService
{
    private readonly OrderContext _orderContext;

    public OrderService(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public List<Order> GetAllOrders()
    {
        return _orderContext.Orders.ToList();
    }

    public Order GetOrderById(Guid id)
    {
        return _orderContext.Orders.Find(id);
    }

    public Order AddOrder(AddOrderDto addOrderDto)
    {
        var orderEntity = new Order
        {
            Name = addOrderDto.Name,
            Quantity = addOrderDto.Quantity
        };

        _orderContext.Orders.Add(orderEntity);
        _orderContext.SaveChanges();

        return orderEntity;
    }

    public Order UpdateOrder(Guid id, UpdateOrderDto updateOrderDto)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return null;

        order.Name = updateOrderDto.Name;
        order.Quantity = updateOrderDto.Quantity;
        _orderContext.SaveChanges();

        return order;
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
