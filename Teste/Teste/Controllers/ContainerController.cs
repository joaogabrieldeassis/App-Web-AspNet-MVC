using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Data;

namespace Teste.Controllers
{
    public class ContainerController : Controller
    {
        private readonly BancoDaAplicacao _bancoDaAplicacao;
        public ContainerController(BancoDaAplicacao bancoDaAplicacao)
        {
            _bancoDaAplicacao = bancoDaAplicacao;
        }

        public async Task<IActionResult> GetContainer()
        {
            return View(await _bancoDaAplicacao.Containers.Include(x => x.Cliente).AsNoTracking().ToListAsync());
        }
    }
}
