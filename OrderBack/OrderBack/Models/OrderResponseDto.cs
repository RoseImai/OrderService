namespace OrderBack.Models;

public class OrderResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}