using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
