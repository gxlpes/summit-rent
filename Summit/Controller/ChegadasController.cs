using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;
using Summit.Requests;

namespace Summit.Controller
{
    [Route("api/chegada")]
    [ApiController]
    public class ChegadasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChegadasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chegada>>> GetChegada()
        {
            return await _context.Chegada.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chegada>> GetChegada(Guid id)
        {
            var chegada = await _context.Chegada.FindAsync(id);

            if (chegada == null)
            {
                return NotFound();
            }

            return chegada;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChegada(Guid id, Chegada chegada)
        {
            if (id != chegada.Id)
            {
                return BadRequest();
            }

            _context.Entry(chegada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChegadaExists(id))
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
        public async Task<ActionResult<Chegada>> PostChegadaSemData (Chegada chegada)
        {
            _context.Chegada.Add(chegada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostChegada", chegada);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChegada(Guid id)
        {
            var chegada = await _context.Chegada.FindAsync(id);
            if (chegada == null)
            {
                return NotFound();
            }

            _context.Chegada.Remove(chegada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChegadaExists(Guid id)
        {
            return _context.Chegada.Any(e => e.Id == id);
        }
    }
}
