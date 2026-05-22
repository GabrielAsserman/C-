using AvaliacaoAPI.Data;
using AvaliacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return Ok(fornecedor);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, Fornecedor fornecedor)
        {
            if (codigo != fornecedor.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(codigo);

            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> BuscarNome(string nome)
        {
            var fornecedores = await _context.Fornecedores
                .Where(f => f.Nome.Contains(nome))
                .ToListAsync();

            return fornecedores;
        }
    }
}
