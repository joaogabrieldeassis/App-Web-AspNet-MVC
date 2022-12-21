using MinhaAp.Busines.Models;

namespace Dev.AppMvc.ViewModels
{
    public class ProdutoViewModel
    {

        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public bool Ativo { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
    }
}
