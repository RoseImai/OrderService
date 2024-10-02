namespace OrderBack.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
