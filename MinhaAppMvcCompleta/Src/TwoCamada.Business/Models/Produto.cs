﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCamada.Business.Models
{
    public class Produto
    {
        public Guid FornecedorId { get; set; } 
        public string Nome { get; set; }   
        public string Descricao { get; set; }  
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public bool Ativo { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
