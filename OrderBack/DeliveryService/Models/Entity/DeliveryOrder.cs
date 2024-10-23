namespace DeliveryService.Models.Entity;

public class DeliveryOrder
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string? OrderName { get; set; }
    public int Quantity { get; set; }
    public string? Status { get; set; }
}