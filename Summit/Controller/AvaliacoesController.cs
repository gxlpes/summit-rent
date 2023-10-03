using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/avaliacao")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvaliacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacao()
        {
            return await _context.Avaliacao.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(Guid id)
        {
            var avaliacao = await _context.Avaliacao.FindAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(Guid id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            if(avaliacao.Aluguel.Chegada?.Data == null)
            {
                return Unauthorized();
            }

            _context.Avaliacao.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacao", new { id = avaliacao.Id }, avaliacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(Guid id)
        {
            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _context.Avaliacao.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoExists(Guid id)
        {
            return _context.Avaliacao.Any(e => e.Id == id);
        }
    }
}
