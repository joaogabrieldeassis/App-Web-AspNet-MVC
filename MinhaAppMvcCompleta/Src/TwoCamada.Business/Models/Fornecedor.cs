using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoCamada.Business.Models.Enuns;

namespace TwoCamada.Business.Models
{
    public class Fornecedor
    {
        
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoDeFornecedor TipoDeFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
