using Microsoft.EntityFrameworkCore;
using PickPoint.Integration.Store.OrderService.Models;

namespace PickPoint.Integration.Store.OrderService.Data
{
    public class OrderServiceContext : DbContext
    {
        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {
        }
        public DbSet<Postamat> Postamats { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
