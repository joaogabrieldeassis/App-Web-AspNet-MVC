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
using AutoMapper;

namespace Dev.AppMvc.Controllers
{
    public class FornecedoresViewModelsController : Controller
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresViewModelsController(IFornecedorRepository fornecedorRepository,IMapper mapper)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }

        
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<FornecedorViewModel>>( await _fornecedorRepository.ObterTodos()));
        }

        
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

        
        public IActionResult Create()
        {
            return View();
        }

        
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
