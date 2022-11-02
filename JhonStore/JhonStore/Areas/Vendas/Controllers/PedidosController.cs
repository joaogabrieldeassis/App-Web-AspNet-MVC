using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Modulos.Vendas.Controllers
{
    [Area("Vendas")]
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        [Route("listar")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
