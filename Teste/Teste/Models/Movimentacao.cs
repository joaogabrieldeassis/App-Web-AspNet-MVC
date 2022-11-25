using Teste.Models.Enuns.EnunsMovimentacao;

namespace Teste.Models
{
    public class Movimentacao : Entity
    {
        public TipoDaMovimentacao TipoDaMovimentacao { get; set; }
        public DateTime DataEhorarioDeInicio { get; set; }
        public DateTime DataEhorarioDoFim { get; set; }
    }
}
