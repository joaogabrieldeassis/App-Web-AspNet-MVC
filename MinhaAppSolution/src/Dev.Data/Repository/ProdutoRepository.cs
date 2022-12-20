using MinhaAp.Busines.Models;
using Dev.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dev.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos.AsNoTracking().Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(x => x.FornecedorId == fornecedorId);
           
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedores()
        {
            return await _context.Produtos.AsNoTracking().Include(x => x.Fornecedor)
               .OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
