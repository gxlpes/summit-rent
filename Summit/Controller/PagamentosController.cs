using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PagamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamento()
        {
            return await _context.Pagamento.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(Guid id)
        {
            var pagamento = await _context.Pagamento.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(Guid id, Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamento", new { id = pagamento.Id }, pagamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(Guid id)
        {
            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoExists(Guid id)
        {
            return _context.Pagamento.Any(e => e.Id == id);
        }
    }
}
