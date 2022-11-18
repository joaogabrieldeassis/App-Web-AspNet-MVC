using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;
        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogError("Mostrando o erro no console");
            return View();
        }
    }
}
