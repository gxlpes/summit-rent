using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/saida")]
    [ApiController]
    public class SaidasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Saidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saida>>> GetSaida()
        {
            return await _context.Saida.ToListAsync();
        }

        // GET: api/Saidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saida>> GetSaida(Guid id)
        {
            var saida = await _context.Saida.FindAsync(id);

            if (saida == null)
            {
                return NotFound();
            }

            return saida;
        }

        // PUT: api/Saidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaida(Guid id, Saida saida)
        {
            if (id != saida.Id)
            {
                return BadRequest();
            }

            _context.Entry(saida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaExists(id))
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

        // POST: api/Saidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Saida>> PostSaida(Saida saida)
        {
            _context.Saida.Add(saida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaida", new { id = saida.Id }, saida);
        }

        // DELETE: api/Saidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaida(Guid id)
        {
            var saida = await _context.Saida.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }

            _context.Saida.Remove(saida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaidaExists(Guid id)
        {
            return _context.Saida.Any(e => e.Id == id);
        }
    }
}
