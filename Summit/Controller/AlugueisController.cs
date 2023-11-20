using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;
using Summit.Requests;

namespace Summit.Controller
{
    [Route("api/aluguel")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlugueisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAluguel()
        {
            return await _context.Aluguel.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluguel>> GetAluguel(Guid id)
        {
            var aluguel = await _context.Aluguel.FindAsync(id);

            if (aluguel == null)
            {
                return NotFound();
            }

            return aluguel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(Guid id, Aluguel aluguel)
        {
            if (id != aluguel.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
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
        public async Task<ActionResult<Aluguel>> PostAluguel(AluguelRequest aluguelRequest)
        {
            var clienteFazendoReq = await _context.Tentativa.FindAsync(aluguelRequest.ClienteId);

            if (clienteFazendoReq == null)
            {
                return Unauthorized();
            }

            var carro = await _context.Carro.FindAsync(aluguelRequest.CarroId);
            var cliente = await _context.Cliente.FindAsync(aluguelRequest.ClienteId);
            var pagamento = await _context.Pagamento.FindAsync(aluguelRequest.PagamentoId);
            var seguro = await _context.Seguro.FindAsync(aluguelRequest.SeguroId);
            var saida = await _context.Saida.FindAsync(aluguelRequest.SaidaId);
            var chegada = await _context.Chegada.FindAsync(aluguelRequest.ChegadaId);

            Aluguel aluguel = new(DateTime.Now, carro, cliente, pagamento, seguro, saida, chegada);

            _context.Aluguel.Add(aluguel);
            await _context.SaveChangesAsync();

            var tentativas = await _context.Tentativa.Where(t => t.ClienteId == aluguelRequest.ClienteId).ToListAsync();
            _context.Tentativa.RemoveRange(tentativas);

            return CreatedAtAction("GetAluguel", new { id = aluguel.Id }, aluguel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(Guid id)
        {
            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            _context.Aluguel.Remove(aluguel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AluguelExists(Guid id)
        {
            return _context.Aluguel.Any(e => e.Id == id);
        }
    }
}
