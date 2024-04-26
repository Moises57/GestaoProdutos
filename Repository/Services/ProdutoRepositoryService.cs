using Domain.Entities;
using Domain.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Services
{
    public class ProdutoRepositoryService : IProdutoRepository
    {

        private readonly ProdutoContext _context;
        private readonly DbSet<Produto> DbSet;
        public ProdutoRepositoryService(ProdutoContext context)
        {
            _context = context;
            DbSet = _context.Set<Produto>();

        }

        public void Add(Produto produto)
        {
            DbSet.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> GetAll(int skip, int take)
        {
           return _context.Produtos.Skip(skip).Take(take).ToList();
        }

        public Produto GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(Produto produto)
        {
            DbSet.Update(produto);
            _context.SaveChanges();
        }
    }
}
