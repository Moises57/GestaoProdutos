
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
                
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
