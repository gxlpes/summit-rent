using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/seguro")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SegurosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguro>>> GetSeguro()
        {
            return await _context.Seguro.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seguro>> GetSeguro(int id)
        {
            var seguro = await _context.Seguro.FindAsync(id);

            if (seguro == null)
            {
                return NotFound();
            }

            return seguro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguro(Guid id, Seguro seguro)
        {
            if (id != seguro.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroExists(id))
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
        public async Task<ActionResult<Seguro>> PostSeguro(Seguro seguro)
        {
            _context.Seguro.Add(seguro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguro", new { id = seguro.Id }, seguro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguro(int id)
        {
            var seguro = await _context.Seguro.FindAsync(id);
            if (seguro == null)
            {
                return NotFound();
            }

            _context.Seguro.Remove(seguro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguroExists(Guid id)
        {
            return _context.Seguro.Any(e => e.Id == id);
        }
    }
}
