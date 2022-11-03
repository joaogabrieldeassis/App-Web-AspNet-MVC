using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Areas.Joao2Teste.Controllers
{
    [Area("Joao2Teste")]
    [Route("cadastro")]
    public class Joaogabriel : Controller
    {
        [Route("cadastre")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
