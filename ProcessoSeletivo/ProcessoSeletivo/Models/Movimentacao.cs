using ProcessoSeletivo.Models.Enus.EnunsDaMovimentacao;
using ProcessoSeletivo.Models.Enus.EnunsDoContainer;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Models
{
    public class Movimentacao : Entity
    {
        public TipoDaMovimentacao Status { get; set; }
        [Required]
        [MaxLength(12)]
        public DateTime DataDeInicio { get; set; }
        [Required]
        [MaxLength(12)]
        public DateTime DataFinal { get; set; }

    }
}
