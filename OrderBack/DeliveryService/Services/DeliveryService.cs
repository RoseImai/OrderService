using AutoMapper;
using DeliveryService.Data;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Services;

public class DeliveryService : IDeliveryService
{
    private readonly DeliveryContext _deliveryContext;
    private readonly IMapper _mapper;

    public DeliveryService(DeliveryContext deliveryContext, IMapper mapper)
    {
        _deliveryContext = deliveryContext;
        _mapper = mapper;
    }
    public IEnumerable<DeliveryResponseDto> GetAllDelivery()
    {
        var deliveries = _deliveryContext.DeliveryOrders.ToList();
        return _mapper.Map<IEnumerable<DeliveryResponseDto>>(deliveries);
    }

    public DeliveryResponseDto? GetDeliveryById(Guid id)
    {
        var delivery = _deliveryContext.DeliveryOrders.Find(id);
        if (delivery is null) return null;

        return _mapper.Map<DeliveryResponseDto>(delivery);
    }
}