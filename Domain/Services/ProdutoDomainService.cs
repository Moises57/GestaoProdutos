using Domain.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Infra.Repository.Interfaces;

namespace Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private string mensagemValidaData = String.Empty;
        public ProdutoDomainService(IMapper mapper
            , IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public string AtualizarProduto(int id, UpdateProdutoDto produtoDto)
        {
            if (!ValidaSedatasForamInformadas(produtoDto.DataFabricacao, produtoDto.DataValidade))
                return "Ao informar uma data, a outra data também deverá ser informada";

            if (!ValidaDataCadastro(produtoDto.DataFabricacao, produtoDto.DataValidade))
            {
                var produto = _produtoRepository.GetById(id);
                if (produto == null)
                    return mensagemValidaData = "Nenhum Produto encontrado";

                var produtoMap = _mapper.Map(produtoDto, produto);
                _produtoRepository.Update(produtoMap);
                mensagemValidaData = "Produto atualizado com sucesso";

            }
            else
            {
                mensagemValidaData = "Data Fabricação não pode ser maior do que a Data de Validade";
            };

            return mensagemValidaData;
        }

        public ReadProdutoDto BuscarProdutoPorId(int id)
        {
            var produto = _produtoRepository.GetById(id);
            var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
            return produtoDto;
        }

        public IEnumerable<ReadProdutoDto> BuscarTodosProdutos(int skip, int take)
        {
           return _mapper.Map<List<ReadProdutoDto>>(_produtoRepository.GetAll(skip, take));
        }

        public string CadastrarProduto(CreateProdutoDto produtoDto)
        {
            if (!ValidaSedatasForamInformadas(produtoDto.DataFabricacao, produtoDto.DataValidade))
                return "Ao informar uma data, a outra data também deverá ser informada";

            if (!ValidaDataCadastro(produtoDto.DataFabricacao, produtoDto.DataValidade))
            {
                Produto produtoMapeado = _mapper.Map<Produto>(produtoDto);
                _produtoRepository.Add(produtoMapeado);
                mensagemValidaData = "Produto cadastrado com sucesso";
            }
            else
            {
                mensagemValidaData = "Data Fabricação não pode ser maior ou igual a Data de Validade";
            };

            return mensagemValidaData;
        }

        public string DeletarProduto(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
                return mensagemValidaData = "Nenhum Produto encontrado";

            produto.SituacaoProduto = false;
            _produtoRepository.Update(produto);
            return mensagemValidaData = "Produto deletado com sucesso";
        }

        public bool ValidaDataCadastro(DateTime? dataFabricacao, DateTime? dataValidade)
        {
            if (dataFabricacao.HasValue && dataValidade.HasValue)
            {
                var comparaDatas = DateTime.Compare(Convert.ToDateTime(dataFabricacao), Convert.ToDateTime(dataValidade));
                if (comparaDatas >= 0)
                    return true;
            }
            else
            {
                return false;
            }

            return false;

        }

        public bool ValidaSedatasForamInformadas(DateTime? dataFabricacao, DateTime? dataValidade)
        {
            if (!dataFabricacao.HasValue && !dataValidade.HasValue)
            {
                return true;
            }
            else
            {
                if (dataFabricacao.HasValue && dataValidade.HasValue)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }
    }
}
