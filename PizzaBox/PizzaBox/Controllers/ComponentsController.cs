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
    [Route("api/Components")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly PizzaBoxContext _context;

        // DbContext is injected in Controller
        public ComponentsController(PizzaBoxContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acomponent>>> GetAcomponents()
        {
            return await _context.Acomponents.ToListAsync();
        }

        // GET: api/Components/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acomponent>> GetAcomponent(int id)
        {
            var acomponent = await _context.Acomponents.FindAsync(id);

            if (acomponent == null)
            {
                return NotFound();
            }

            return acomponent;
        }

        // PUT: api/Components/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcomponent(int id, Acomponent acomponent)
        {
            if (id != acomponent.AcomponentId)
            {
                return BadRequest();
            }

            _context.Entry(acomponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcomponentExists(id))
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

        // POST: api/Components
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acomponent>> PostAcomponent(Acomponent acomponent)
        {
            _context.Acomponents.Add(acomponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAcomponent), new { id = acomponent.AcomponentId }, acomponent);
        }

        // DELETE: api/Components/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcomponent(int id)
        {
            var acomponent = await _context.Acomponents.FindAsync(id);
            if (acomponent == null)
            {
                return NotFound();
            }

            _context.Acomponents.Remove(acomponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcomponentExists(int id)
        {
            return _context.Acomponents.Any(e => e.AcomponentId == id);
        }
    }
}
