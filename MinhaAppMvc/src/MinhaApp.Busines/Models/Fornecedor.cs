using MinhaApp.Busines.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApp.Busines.Models
{
    public class Fornecedor
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoDoFornecedor TipoDoFornecedor { get; set; }        
        public bool Ativo { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerator<Produto> Produtos { get; set; }
    }
}
