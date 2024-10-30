using DeliveryService.Data;
using DeliveryService.Models.Entity;
using MassTransit;
using OrderBack.Messages;

namespace DeliveryService.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    private readonly DeliveryContext _deliveryContext;
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(DeliveryContext deliveryContext, ILogger<OrderCreatedConsumer> logger)
    {
        _deliveryContext = deliveryContext;
        _logger = logger;
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
            _logger.LogInformation("Successfully got Message: {0}", context.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Ошибка при обработке сообщения: {0}", context.Message);
            throw;
        }
    }
}