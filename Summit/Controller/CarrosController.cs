using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/carro")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarro()
        {
            return await _context.Carro.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(Guid id)
        {
            var carro = await _context.Carro.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(Guid id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            _context.Carro.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(Guid id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(Guid id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}
