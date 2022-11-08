using JhonStore.Controllers.Data;
using JhonStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            var studantTree = _context.Alunos.FirstOrDefault(x => x.Nome == "Jesus");
            var studantFor = _context.Alunos.Where(x => x.DataDeNascimento == DateTime.Now);

            aluno.Email = "joaoassis";
            _context.SaveChanges();

            _context.Entry(aluno.Id).State = EntityState.Deleted;
            return View();
        }
    }
}
