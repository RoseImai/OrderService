using DeliveryService.Data;
//using DeliveryService.Messages;
using DeliveryService.Models.Entity;
using MassTransit;
using OrderBack.Messages;

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
        try
        {
            Console.WriteLine($"Received data: ID = {context.Message.Id}, NAME = {context.Message.Name}");
            var delivery = new DeliveryOrder
            {
                OrderId = context.Message.Id,
                OrderName = context.Message.Name,
                Quantity = context.Message.Quantity,
                Status = "Shipping"
            };
                    
            _deliveryContext.DeliveryOrders.Add(delivery);
            await _deliveryContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}