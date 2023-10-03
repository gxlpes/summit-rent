using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/tentativa")]
    [ApiController]
    public class TentativasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TentativasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tentativa>>> GetTentativa()
        {
            return await _context.Tentativa.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tentativa>> GetTentativa(Guid id)
        {
            var tentativa = await _context.Tentativa.FindAsync(id);

            if (tentativa == null)
            {
                return NotFound();
            }

            return tentativa;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTentativa(Guid id, Tentativa tentativa)
        {
            if (id != tentativa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tentativa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TentativaExists(id))
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
        public async Task<ActionResult<Tentativa>> PostTentativa(Tentativa tentativa)
        {
            _context.Tentativa.Add(tentativa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTentativa", new { id = tentativa.Id }, tentativa);
        }

        private bool TentativaExists(Guid id)
        {
            return _context.Tentativa.Any(e => e.Id == id);
        }
    }
}
