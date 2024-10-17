using MassTransit;
using OrderBack.Messages;

namespace OrderBack.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received order: {message.Id}, {message.Name}, {message.Quantity}");
        
        return Task.CompletedTask;
    }
}