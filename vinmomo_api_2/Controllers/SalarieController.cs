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
            return await _context.Salaries
                .Include(s => s.Site)
                .Include(s => s.Service)
                .ToListAsync();
        }

        // GET: api/Salarie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarie>> GetSalarie(int id)
        {
            var salarie = await _context.Salaries
                .Include(s => s.Site)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (salarie == null)
                return NotFound();

            return salarie;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalarie(int id, Salarie salarie)
        {
            if (id != salarie.Id)
                return BadRequest();

            _context.Entry(salarie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Salarie>> PostSalarie(Salarie salarie)
        {
            _context.Salaries.Add(salarie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalarie), new { id = salarie.Id }, salarie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarie(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null)
                return NotFound();

            _context.Salaries.Remove(salarie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
