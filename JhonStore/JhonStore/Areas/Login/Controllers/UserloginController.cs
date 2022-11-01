using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Areas.Login.Controllers
{
    public class UserloginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
