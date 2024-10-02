using OrderBack.Models;

namespace OrderBack.Interfaces;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order GetOrderById(Guid id);
    Order AddOrder(AddOrderDto addOrderDto);
    Order UpdateOrder(Guid id, UpdateOrderDto updateOrderDto);
    bool DeleteOrder(Guid id);
}
