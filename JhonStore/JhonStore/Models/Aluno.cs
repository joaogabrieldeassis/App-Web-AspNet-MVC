namespace JhonStore.Models
{
    public class Aluno
    {
        public Aluno()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id{ get; set; }
        public string Nome{ get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        
    }
}
