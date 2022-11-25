using Teste.Models.Enuns.EnunsContainer;

namespace Teste.Models
{
    public class Container : Entity
    {
        public Cliente Cliente { get; set; }
        public string NumeroDeContainer { get; set; }
        public Tipo Tipo { get; set; }
        public Status Status { get; set; }
        public Categoria Categoria { get; set; }
    }
}
