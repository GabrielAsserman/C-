using Microsoft.EntityFrameworkCore;
using AvaliacaoAPI.Models;

namespace AvaliacaoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }
    }
}
