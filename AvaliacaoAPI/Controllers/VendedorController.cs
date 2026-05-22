using AvaliacaoAPI.Data;
using AvaliacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> Get()
        {
            return await _context.Vendedores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return Ok(vendedor);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, Vendedor vendedor)
        {
            if (codigo != vendedor.Codigo)
                return BadRequest();

            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            var vendedor = await _context.Vendedores.FindAsync(codigo);
            if (vendedor == null)
                return NotFound();

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("salario/{valor}")]
        public async Task<ActionResult<IEnumerable<Vendedor>>> BuscarSalario(decimal valor)
        {
            var vendedores = await _context.Vendedores
                .Where(v => v.Salario > valor)
                .ToListAsync();
            return vendedores;
        }
    }
}