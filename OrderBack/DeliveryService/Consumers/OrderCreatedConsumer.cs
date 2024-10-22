using DeliveryService.Data;
using DeliveryService.Messages;
using DeliveryService.Models.Entity;
using MassTransit;

namespace DeliveryService.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    private readonly DeliveryContext _deliveryContext;

    public OrderCreatedConsumer(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }

    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        var delivery = new DeliveryOrder
        {
            Id = context.Message.Id,
            OrderName = context.Message.Name,
            Quantity = context.Message.Quantity,
            OrderDate = context.SentTime.Value
        };
        
        _deliveryContext.DeliveryOrders.Add(delivery);
        await _deliveryContext.SaveChangesAsync();
    }
}