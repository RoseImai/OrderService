using OrderBack.Models;
using OrderBack.Models.Entities;

namespace OrderBack.Interfaces;

public interface IOrderService
{
    IEnumerable<OrderResponseDto> GetAllOrders();
    OrderResponseDto? GetOrderById(Guid id);
    OrderResponseDto? AddOrder(AddOrderDto addOrderDto);
    OrderResponseDto? UpdateOrder(Guid id, UpdateOrderDto updateOrderDto);
    bool DeleteOrder(Guid id);
}
