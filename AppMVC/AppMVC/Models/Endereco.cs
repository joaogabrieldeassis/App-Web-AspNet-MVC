using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models
{
    public class Endereco : Entity
    {
        public Guid FornecedorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 1)]
        public string Numero { get; set; }

        public string Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter {1}", MinimumLength = 8)]
        public string Cep{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Bairro{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Cidade{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Estado { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
