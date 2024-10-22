namespace DeliveryService.Models.Entity;

public class DeliveryOrder
{
    public Guid Id { get; set; }
    public string? OrderName { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}