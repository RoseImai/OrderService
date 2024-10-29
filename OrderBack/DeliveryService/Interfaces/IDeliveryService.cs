using DeliveryService.Models;

namespace DeliveryService.Interfaces;

public interface IDeliveryService
{
    IEnumerable<DeliveryResponseDto> GetAllDelivery();
    DeliveryResponseDto? GetDeliveryById(Guid id);
}