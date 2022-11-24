using AppMVC.Models.Enuns;

namespace AppMVC.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento{ get; set; }
        public TipoDeFornecedor TipoDeFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
