using Microsoft.EntityFrameworkCore;
using PickPoint.Integration.Store.OrderService.Models;

namespace PickPoint.Integration.Store.OrderService.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrderServiceContext(serviceProvider.GetRequiredService<DbContextOptions<OrderServiceContext>>()))
            {
                if (context.Postamats.Any()) // Data was already seeded
                    return;

                var t1 = new Postamat { Id = "0000-001", Address = "Address 1" };
                var t2 = new Postamat { Id = "0000-002", Address = "Address 2" };

                context.Postamats.AddRange(t1, t2);

                var p1 = new Product { Name = "Компьютер" };
                var p2 = new Product { Name = "Холодильник" };
                var p3 = new Product { Name = "Чайник" };
                var p4 = new Product { Name = "Утюг" };

                context.Products.AddRange(p1, p2, p3, p4);

                var r1 = new Recipient { Name = "Иванов И.И.", Phone = "+7123-455-78-90" };
                var r2 = new Recipient { Name = "Петров П.П.", Phone = "+7123-455-78-91" };

                context.Recipients.AddRange(r1, r2);

                var o1 = new Order
                {
                    Cost = 10000,
                    PostamatId = "0000-001",
                    RecipientId = 1,
                    Status = OrderStatus.Registered,
                    Products = new List<Product> { p2, p3 }
                };

                var o2 = new Order
                {
                    Cost = 20000,
                    PostamatId = "0000-002",
                    RecipientId = 2,
                    Status = OrderStatus.Registered,
                    Products = new List<Product> { p1, p4 }
                };

                context.Orders.AddRange(o1, o2);

                context.SaveChanges();
            }
        }
    }
}
