#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickPoint.Integration.Store.OrderService.Data;
using PickPoint.Integration.Store.OrderService.Dto;
using PickPoint.Integration.Store.OrderService.Models;

namespace PickPoint.Integration.Store.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderServiceContext context;

        public OrdersController(OrderServiceContext context)
        {
            this.context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await context.Orders.Include(p => p.Products).Include(t => t.Postamat).Include(r => r.Recipient).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var order = await context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, [FromQuery] OrderDto orderDto)
        {
            var order = await context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            order.Cost = orderDto.Cost;
            order.PostamatId = orderDto.PostamatId;
            order.RecipientId = orderDto.RecipientId;
            order.Products = new List<Product>();

            foreach (var productId in orderDto.Products)
            {
                var product = await context.Products.FindAsync(productId);

                if (product == null)
                    return BadRequest();

                order.Products.Add(product);
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromQuery] OrderDto order)
        {
            if (!order.IsValid)
            {
                return BadRequest();
            }

            Order newOrder = new Order
            {
                Cost = order.Cost,
                PostamatId = order.PostamatId,
                RecipientId = order.RecipientId, 
                Products = new List<Product>(),
            };

            foreach (var productId in order.Products)
            {
                var product = await context.Products.FindAsync(productId);

                if (product == null)
                    return BadRequest();

                newOrder.Products.Add(product);
            }

            context.Orders.Add(newOrder);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDto(long id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(long id)
        {
            return context.Orders.Any(e => e.Id == id);
        }
    }
}
