using Application.Services;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoApplicationService _applicationProdutoService;

        public ProdutoController(IProdutoApplicationService applicationProdutoService)
        {
            _applicationProdutoService = applicationProdutoService;
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] CreateProdutoDto produtoDto)
        {
           var retorno = _applicationProdutoService.CadastrarProduto(produtoDto);
            return Ok(retorno);
        }

        [HttpGet]
        public IEnumerable<ReadProdutoDto> RecuperaFilmes([FromQuery] int skip, int take)
        {
            return _applicationProdutoService.BuscarTodosProdutos(skip, take);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProdutoPorId(int id)
        {
            var produtoDto = _applicationProdutoService.BuscarProdutoPorId(id);
            if (produtoDto == null) return BadRequest("Nenhum produto encontrado.");

            return Ok(produtoDto);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProdutoPorId(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
           var mensagemRetorno = _applicationProdutoService.AtualizarProduto(id, produtoDto);
            return Ok(mensagemRetorno);

        }

        [HttpDelete ("{id}")]
        public IActionResult DeletarProdutoPorId(int id)
        {
            var mensagemRetorno = _applicationProdutoService.DeletarProduto(id);
            return Ok(mensagemRetorno);

        }
    }
}
