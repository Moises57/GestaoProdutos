using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Produto
    {
        [Key]
        [Required]
        public int CodigoProduto { get; set; }
        [StringLength(300, ErrorMessage = "O tamanho máximo é de 300 caracteres")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória")]
        public required string DescricaoProduto { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        public string DescricaoFornecedor { get; set; }

        [StringLength(18,MinimumLength = 18, ErrorMessage = "O CNPJ do Fornecedor deve ter 18 caracteres")]
        public string CNPJFornecedor { get; set; }
    }
}
