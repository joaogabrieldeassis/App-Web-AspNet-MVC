using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Modulos.Products.Controllers
{
    [Area("Products")]
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
