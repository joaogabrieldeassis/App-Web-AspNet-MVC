using JhonStore.Controllers.Data;
using JhonStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhonStore.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MyDbContext _context;
        public TesteCrudController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Jesus",
                Email = "joao",
                DataDeNascimento = DateTime.Now
            };
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var studantsTwo = _context.Alunos.Find(aluno.Id);
            return View();
        }
    }
}
