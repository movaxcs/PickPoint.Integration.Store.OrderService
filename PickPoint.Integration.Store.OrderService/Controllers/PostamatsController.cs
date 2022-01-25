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
    public class PostamatsController : ControllerBase
    {
        private readonly OrderServiceContext context;

        public PostamatsController(OrderServiceContext context)
        {
            this.context = context;
        }

        // GET: api/Postamats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postamat>>> GetPostamats()
        {
            return await context.Postamats.ToListAsync();
        }

        // GET: api/Postamats
        [HttpGet("Worked")]
        public async Task<ActionResult<IEnumerable<Postamat>>> GetWorkedPostamats()
        {
            return await context.Postamats.Where(s => s.Status == PostamatStatus.Worked).OrderBy(o => o.Id).ToListAsync();
        }

        // GET: api/Postamats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postamat>> GetPostamat(string id)
        {
            var postamat = await context.Postamats.FindAsync(id);

            if (postamat == null)
            {
                return NotFound();
            }

            return postamat;
        }

        // PUT: api/Postamats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostamat(string id, [FromQuery] Postamat postamat)
        {
            if (id != postamat.Id || !postamat.IsValid)
            {
                return BadRequest();
            }

            context.Entry(postamat).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostamatExists(id))
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

        // POST: api/Postamats
        [HttpPost]
        public async Task<ActionResult<Postamat>> PostPostamat([FromQuery] Postamat postamat)
        {
            if (!postamat.IsValid)
            {
                return BadRequest();
            }

            context.Postamats.Add(postamat);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostamatExists(postamat.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetPostamat), new { id = postamat.Id }, postamat);
        }

        // DELETE: api/Postamats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostamat(string id)
        {
            var postamat = await context.Postamats.FindAsync(id);
            if (postamat == null)
            {
                return NotFound();
            }

            context.Postamats.Remove(postamat);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostamatExists(string id)
        {
            return context.Postamats.Any(e => e.Id == id);
        }
    }
}
