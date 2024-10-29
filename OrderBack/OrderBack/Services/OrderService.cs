using AutoMapper;
using MassTransit;
using OrderBack.Data;
using OrderBack.Interfaces;
using OrderBack.Messages;
using OrderBack.Models;
using OrderBack.Models.Entities;

namespace OrderBack.Services;


public class OrderService : IOrderService
{
    private readonly OrderContext _orderContext;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;


    public OrderService(OrderContext orderContext, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        _orderContext = orderContext;
        _mapper = mapper;
    }

    public IEnumerable<OrderResponseDto> GetAllOrders()
    {
        var orders = _orderContext.Orders.ToList();
        return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
    }

    public OrderResponseDto? GetOrderById(Guid id)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return null;

        return _mapper.Map<OrderResponseDto>(order);
    }

    public OrderResponseDto AddOrder(AddOrderDto newOrder)
    {
        var order = _mapper.Map<Order>(newOrder);
        
        _orderContext.Orders.Add(order);
        _orderContext.SaveChanges();
        
        var orderCreatedEvent = _mapper.Map<OrderCreated>(order);
        _publishEndpoint.Publish(orderCreatedEvent);

        return _mapper.Map<OrderResponseDto>(order);
    }

    public OrderResponseDto? UpdateOrder(Guid id, UpdateOrderDto updateOrder)
    {
        var order = _orderContext.Orders.Find(id);
        if (order is null) return null;

        _mapper.Map(updateOrder, order);

        _orderContext.SaveChanges();

        return _mapper.Map<OrderResponseDto>(order);
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
