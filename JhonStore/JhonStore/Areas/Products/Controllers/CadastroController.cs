using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Modulos.Products.Controllers
{
    [Area("Products")]
    [Route("products")]
    public class CadastroController : Controller
    {
        [Route("list")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
