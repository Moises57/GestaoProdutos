using Domain.Dtos;

namespace Application.Services
{
    public interface IProdutoApplicationService
    {
        string CadastrarProduto(CreateProdutoDto produto);
        ReadProdutoDto BuscarProdutoPorId(int id);
        IEnumerable<ReadProdutoDto> BuscarTodosProdutos(int skip, int take);
        string AtualizarProduto(int id, UpdateProdutoDto produto);
        string DeletarProduto(int id);
    }
}
