using Domain.Dtos;
using Domain.Services;

namespace Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutoApplicationService(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }
        public string CadastrarProduto(CreateProdutoDto produtoDto)
        {
          return _produtoDomainService.CadastrarProduto(produtoDto);
            
        }

        public string AtualizarProduto(int id, UpdateProdutoDto produtoDto)
        {
            return _produtoDomainService.AtualizarProduto(id, produtoDto);
        }

        public ReadProdutoDto BuscarProdutoPorId(int id)
        {            
            return _produtoDomainService.BuscarProdutoPorId(id);
        }

        public IEnumerable<ReadProdutoDto> BuscarTodosProdutos(int skip, int take)
        {
            return _produtoDomainService.BuscarTodosProdutos(skip, take);
        }

        public string DeletarProduto(int id)
        {
           return _produtoDomainService.DeletarProduto(id);

        }

    }
}
