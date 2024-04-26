using Domain.Dtos;

namespace Domain.Services
{
    public interface IProdutoDomainService
    {
        bool ValidaDataCadastro(DateTime? dataFabricacao, DateTime? dataValidade);
        bool ValidaSedatasForamInformadas(DateTime? dataFabricacao, DateTime? dataValidade);
        string CadastrarProduto(CreateProdutoDto produto);
        ReadProdutoDto BuscarProdutoPorId(int id);
        IEnumerable<ReadProdutoDto> BuscarTodosProdutos(int skip, int take);
        string AtualizarProduto(int id, UpdateProdutoDto produto);
        string DeletarProduto(int id);
    }
}
