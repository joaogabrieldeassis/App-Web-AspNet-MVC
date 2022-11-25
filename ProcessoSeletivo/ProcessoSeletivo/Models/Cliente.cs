using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Models
{
    public class Cliente : Entity
    {
        
        public Guid ContainerId{ get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "O campo {0} não etende os requisitos",MinimumLength = 2)]
        public string Nome { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "O campo {0} não etende os requisitos", MinimumLength = 1)]
        public int Idade { get; set; }
        [Required]
        [StringLength(9, ErrorMessage = "O campo {0} não etende os requisitos", MinimumLength = 9)]
        public string Rg{ get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} não etende os requisitos", MinimumLength = 5)]
        public string Email { get; set; }
    }
}
