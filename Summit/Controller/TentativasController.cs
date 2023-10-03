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

        [HttpPost]
        public async Task<ActionResult<Tentativa>> PostTentativa(Tentativa tentativa)
        {
            var carro = await _context.Carro.FindAsync(tentativa.CarroId);

            if (carro.Alugado)
            {
                return Unauthorized();
            }

            _context.Tentativa.Add(tentativa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTentativa", new { id = tentativa.ClienteId }, tentativa);
        }

    }
}
