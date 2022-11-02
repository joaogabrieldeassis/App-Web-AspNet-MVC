using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Modulos.Login.Controllers
{
    [Area("Login")]
    [Route("login")]
    public class UserloginController : Controller
    {
        [Route("listLogin")]
        public IActionResult LoginUser()
        {
            return View();
        }
        [Route("teste")]
        public IActionResult Teste()
        {
            return View();
        }
    }
}
