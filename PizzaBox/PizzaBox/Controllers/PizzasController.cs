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
    [Route("api/Pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaBoxContext _context;

        // DbContext is injected in Controller
        public PizzasController(PizzaBoxContext context)
        {
            _context = context;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apizza>>> GetApizzas()
        {
            return await _context.Apizzas.ToListAsync();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apizza>> GetApizza(int id)
        {
            var apizza = await _context.Apizzas.FindAsync(id);

            if (apizza == null)
            {
                return NotFound();
            }

            return apizza;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApizza(int id, Apizza apizza)
        {
            if (id != apizza.ApizzaId)
            {
                return BadRequest();
            }

            _context.Entry(apizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApizzaExists(id))
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

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apizza>> PostApizza(Apizza apizza)
        {
            _context.Apizzas.Add(apizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApizza), new { id = apizza.ApizzaId }, apizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApizza(int id)
        {
            var apizza = await _context.Apizzas.FindAsync(id);
            if (apizza == null)
            {
                return NotFound();
            }

            _context.Apizzas.Remove(apizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApizzaExists(int id)
        {
            return _context.Apizzas.Any(e => e.ApizzaId == id);
        }
    }
}
