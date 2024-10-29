using AutoMapper;
using DeliveryService.Models;
using DeliveryService.Models.Entity;

namespace DeliveryService.Profiles;

public class DeliveryProfile : Profile
{
    public DeliveryProfile()
    {
        CreateMap<DeliveryOrder, DeliveryResponseDto>();
    }
}