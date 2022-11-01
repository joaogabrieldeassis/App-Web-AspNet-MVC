using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Areas.Products.Controllers
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
