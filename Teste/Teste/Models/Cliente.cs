namespace Teste.Models
{
    public class Cliente : Entity
    {
        public Guid ContainerId { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
    }
}
