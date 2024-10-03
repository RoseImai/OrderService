namespace OrderBack.Models.Entities;

public class Order
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
