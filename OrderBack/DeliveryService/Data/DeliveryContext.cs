using DeliveryService.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data;

public class DeliveryContext : DbContext
{
    public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options){}
    
    public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
}