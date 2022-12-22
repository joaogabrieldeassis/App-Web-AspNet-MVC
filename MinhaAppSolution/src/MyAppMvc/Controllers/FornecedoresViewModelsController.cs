using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dev.AppMvc.ViewModels;
using MyAppMvc.Data;
using Dev.Bussines.Interfaces;

namespace Dev.AppMvc.Controllers
{
    public class FornecedoresViewModelsController : Controller
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedoresViewModelsController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        // GET: FornecedoresViewModels
        public async Task<IActionResult> Index()
        {
              return View(await _fornecedorRepository.FornecedorViewModel.ToListAsync());
        }

        // GET: FornecedoresViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _fornecedorRepository.FornecedorViewModel == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = await _fornecedorRepository.FornecedorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        // GET: FornecedoresViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FornecedoresViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Documento,TipoDoFornecedor,Ativo")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorViewModel.Id = Guid.NewGuid();
                _fornecedorRepository.Add(fornecedorViewModel);
                await _fornecedorRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorViewModel);
        }

        // GET: FornecedoresViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _fornecedorRepository.FornecedorViewModel == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = await _fornecedorRepository.FornecedorViewModel.FindAsync(id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: FornecedoresViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Documento,TipoDoFornecedor,Ativo")] FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _fornecedorRepository.Update(fornecedorViewModel);
                    await _fornecedorRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorViewModelExists(fornecedorViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorViewModel);
        }

        // GET: FornecedoresViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _fornecedorRepository.FornecedorViewModel == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = await _fornecedorRepository.FornecedorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        // POST: FornecedoresViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_fornecedorRepository.FornecedorViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FornecedorViewModel'  is null.");
            }
            var fornecedorViewModel = await _fornecedorRepository.FornecedorViewModel.FindAsync(id);
            if (fornecedorViewModel != null)
            {
                _fornecedorRepository.FornecedorViewModel.Remove(fornecedorViewModel);
            }
            
            await _fornecedorRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorViewModelExists(Guid id)
        {
          return _fornecedorRepository.FornecedorViewModel.Any(e => e.Id == id);
        }
    }
}
