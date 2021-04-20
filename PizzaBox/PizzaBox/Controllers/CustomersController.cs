using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
//using BusinessLogic;

namespace PizzaBox.Controllers
{


    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PizzaBoxContext _context;


        // DbContext is injected in Controller
        public CustomersController(PizzaBoxContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acustomer>>> GetAcustomers()
        {
            return await _context.Acustomers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acustomer>> GetAcustomer(int id)
        {
            var acustomer = await _context.Acustomers.FindAsync(id);

            if (acustomer == null)
            {
                return NotFound();
            }

            return acustomer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcustomer(int id, Acustomer acustomer)
        {
            if (id != acustomer.AcustomerId)
            {
                return BadRequest();
            }

            _context.Entry(acustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acustomer>> PostAcustomer(Acustomer acustomer)
        {
            _context.Acustomers.Add(acustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAcustomer), new { id = acustomer.AcustomerId }, acustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcustomer(int id)
        {
            var acustomer = await _context.Acustomers.FindAsync(id);
            if (acustomer == null)
            {
                return NotFound();
            }

            _context.Acustomers.Remove(acustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcustomerExists(int id)
        {
            return _context.Acustomers.Any(e => e.AcustomerId == id);
        }
    }
}
