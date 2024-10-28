using AutoMapper;
using OrderBack.Messages;
using OrderBack.Models;
using OrderBack.Models.Entities;
namespace OrderBack.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponseDto>(); 
        CreateMap<AddOrderDto, Order>(); 
        CreateMap<UpdateOrderDto, Order>();
        CreateMap<Order, OrderCreated>();
    }
}