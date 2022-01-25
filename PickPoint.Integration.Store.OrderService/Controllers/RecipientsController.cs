#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickPoint.Integration.Store.OrderService.Data;
using PickPoint.Integration.Store.OrderService.Models;

namespace PickPoint.Integration.Store.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        private readonly OrderServiceContext context;

        public RecipientsController(OrderServiceContext context)
        {
            this.context = context;
        }

        // GET: api/Recipients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipient>>> GetRecipients()
        {
            return await context.Recipients.ToListAsync();
        }

        // GET: api/Recipients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipient>> GetRecipient(long id)
        {
            var recipient = await context.Recipients.FindAsync(id);

            if (recipient == null)
            {
                return NotFound();
            }

            return recipient;
        }

        // PUT: api/Recipients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipient(long id, [FromQuery] Recipient recipient)
        {
            if (id != recipient.Id || !recipient.IsValid)
            {
                return BadRequest();
            }

            context.Entry(recipient).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipientExists(id))
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

        // POST: api/Recipients
        [HttpPost]
        public async Task<ActionResult<Recipient>> PostRecipient([FromQuery] Recipient recipient)
        {
            if (!recipient.IsValid)
            {
                return BadRequest();
            }

            context.Recipients.Add(recipient);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipient), new { id = recipient.Id }, recipient);
        }

        // DELETE: api/Recipients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipient(long id)
        {
            var recipient = await context.Recipients.FindAsync(id);
            if (recipient == null)
            {
                return NotFound();
            }

            context.Recipients.Remove(recipient);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipientExists(long id)
        {
            return context.Recipients.Any(e => e.Id == id);
        }
    }
}
