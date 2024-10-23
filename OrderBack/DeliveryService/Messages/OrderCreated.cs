namespace DeliveryService.Messages;

public class OrderCreated
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public int Quantity { get; init; }
}