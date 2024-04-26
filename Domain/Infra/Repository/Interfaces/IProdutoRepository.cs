using Domain.Entities;

namespace Domain.Infra.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        Produto GetById(int id);
        List<Produto> GetAll(int skip, int take);
        void Update(Produto produto);
    }
}
