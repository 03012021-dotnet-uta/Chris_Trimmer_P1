using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;


namespace PizzaBox.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaBoxContext _context;

        // DbContext is injected in Controller
        public OrdersController(PizzaBoxContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aorder>>> GetAorders()
        {
            return await _context.Aorders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aorder>> GetAorder(int id)
        {
            var aorder = await _context.Aorders.FindAsync(id);

            if (aorder == null)
            {
                return NotFound();
            }

            return aorder;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAorder(int id, Aorder aorder)
        {
            if (id != aorder.AorderId)
            {
                return BadRequest();
            }

            _context.Entry(aorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AorderExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aorder>> PostAorder(Aorder aorder)
        {
            _context.Aorders.Add(aorder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAorder), new { id = aorder.AorderId }, aorder);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAorder(int id)
        {
            var aorder = await _context.Aorders.FindAsync(id);
            if (aorder == null)
            {
                return NotFound();
            }

            _context.Aorders.Remove(aorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AorderExists(int id)
        {
            return _context.Aorders.Any(e => e.AorderId == id);
        }
    }
}
