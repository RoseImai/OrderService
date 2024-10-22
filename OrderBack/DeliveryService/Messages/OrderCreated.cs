namespace DeliveryService.Messages;

public class OrderCreated
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
}