using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Areas.Login.Controllers
{
    [Area("Login")]
    public class UserloginController : Controller
    {
        public IActionResult LoginUser()
        {
            return View();
        }
    }
}
