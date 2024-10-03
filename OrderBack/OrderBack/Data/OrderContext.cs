using OrderBack.Models;
using OrderBack.Models.Entities;

namespace OrderBack.Data;

using Microsoft.EntityFrameworkCore;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
}
