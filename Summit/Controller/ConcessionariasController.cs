using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/concessionaria")]
    [ApiController]
    public class ConcessionariasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConcessionariasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concessionaria>>> GetConcessionaria()
        {
            return await _context.Concessionaria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Concessionaria>> GetConcessionaria(Guid id)
        {
            var concessionaria = await _context.Concessionaria.FindAsync(id);

            if (concessionaria == null)
            {
                return NotFound();
            }

            return concessionaria;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcessionaria(Guid id, Concessionaria concessionaria)
        {
            if (id != concessionaria.Id)
            {
                return BadRequest();
            }

            _context.Entry(concessionaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcessionariaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Concessionaria>> PostConcessionaria(Concessionaria concessionaria)
        {
            _context.Concessionaria.Add(concessionaria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcessionaria", new { id = concessionaria.Id }, concessionaria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionaria(Guid id)
        {
            var concessionaria = await _context.Concessionaria.FindAsync(id);
            if (concessionaria == null)
            {
                return NotFound();
            }

            _context.Concessionaria.Remove(concessionaria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcessionariaExists(Guid id)
        {
            return _context.Concessionaria.Any(e => e.Id == id);
        }
    }
}
