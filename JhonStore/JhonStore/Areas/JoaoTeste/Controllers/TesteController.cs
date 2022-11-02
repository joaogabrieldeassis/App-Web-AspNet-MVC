using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Areas.JoaoTeste.Controllers
{
    [Area("JoaoTeste")]
    [Route("joao")]
    public class TesteController : Controller
    {

        [Route("list/{id?}/{nome?}")]
        public IActionResult Index(int id, string nome)
        {
           return View();
        }
    }
}
