using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vinmomo_api_2.Data;
using vinmomo_api_2.Models;

namespace vinmomo_api_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalarieController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public SalarieController(AnnuaireContext context)
        {
            _context = context;
        }

        // GET: api/Salarie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetSalaries()
        {
            return await _context.Salaries.ToListAsync();
        }

        // GET: api/Salarie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarie>> GetSalarie(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);

            if (salarie == null)
            {
                return NotFound();
            }

            return salarie;
        }

        // PUT: api/Salarie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalarie(int id, Salarie salarie)
        {
            if (id != salarie.Id)
            {
                return BadRequest();
            }

            _context.Entry(salarie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalarieExists(id))
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

        // POST: api/Salarie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salarie>> PostSalarie(Salarie salarie)
        {
            _context.Salaries.Add(salarie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalarie", new { id = salarie.Id }, salarie);
        }

        // DELETE: api/Salarie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarie(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null)
            {
                return NotFound();
            }

            _context.Salaries.Remove(salarie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalarieExists(int id)
        {
            return _context.Salaries.Any(e => e.Id == id);
        }
    }
}
