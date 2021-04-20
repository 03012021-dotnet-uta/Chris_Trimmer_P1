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
    [Route("api/Stores")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly PizzaBoxContext _context;


        // DbContext is injected in Controller
        public StoresController(PizzaBoxContext context)
        {
            _context = context;
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Astore>>> GetAstores()
        {
            return await _context.Astores.ToListAsync();
        }

        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Astore>> GetAstore(int id)
        {
            var astore = await _context.Astores.FindAsync(id);

            if (astore == null)
            {
                return NotFound();
            }

            return astore;
        }

        // PUT: api/Stores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAstore(int id, Astore astore)
        {
            if (id != astore.AstoreId)
            {
                return BadRequest();
            }

            _context.Entry(astore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AstoreExists(id))
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

        // POST: api/Stores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Astore>> PostAstore(Astore astore)
        {
            _context.Astores.Add(astore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAstore), new { id = astore.AstoreId }, astore);
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAstore(int id)
        {
            var astore = await _context.Astores.FindAsync(id);
            if (astore == null)
            {
                return NotFound();
            }

            _context.Astores.Remove(astore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AstoreExists(int id)
        {
            return _context.Astores.Any(e => e.AstoreId == id);
        }
    }
}
