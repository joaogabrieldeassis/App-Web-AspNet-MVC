using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Diagnostics;
using WebApplication2.Extensions;
using WebApplication2.Models;
using static WebApplication2.Extensions.CustomAutorization;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Secruty()
        {
            return View();
        }
        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View();
        }
        [ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult ClaimsCustom()
        {
            return View();
        }
        [ClaimsAuthorize("Listar", "Hoteis")]
        public IActionResult ClaimsAdd()
        {
            return View();
        }
        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var erroDaModel = new ErrorViewModel();
            if (id == 500)
            {
                erroDaModel.Message = "Ocorreu um erro! Tente novamente mais tarde";
                erroDaModel.Titulo = "Ocorreu um erro";
                erroDaModel.ErrorCode = id;
            }
            else if (id == 404)
            {
                erroDaModel.Message = "Ocorreu um erro! Tente novamente mais tarde";
                erroDaModel.Titulo = "Pagina não encontrada";
                erroDaModel.ErrorCode = id;
            }
            else if (id == 403)
            {
                erroDaModel.Message = "Ocorreu um erro! Tente novamente mais tarde";
                erroDaModel.Titulo = "Você não tem permissão para fazer isso";
                erroDaModel.ErrorCode = id;
            }
            else 
            {
                return StatusCode(404);
            }
            return View("Error",erroDaModel);
        }
    }
}