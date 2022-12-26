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
    public class ProdutOsController : BaseControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutOsController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: ProdutOs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdutoViewModel.Include(p => p.Fornecedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdutOs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ProdutoViewModel == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: ProdutOs/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Set<FornecedorViewModel>(), "Id", "Documento");
            return View();
        }

        // POST: ProdutOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,FornecedorId,Descricao,Imagem,Valor,Ativo")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                produtoViewModel.Id = Guid.NewGuid();
                _context.Add(produtoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Set<FornecedorViewModel>(), "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: ProdutOs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ProdutoViewModel == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel.FindAsync(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Set<FornecedorViewModel>(), "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // POST: ProdutOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,FornecedorId,Descricao,Imagem,Valor,Ativo")] ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoViewModelExists(produtoViewModel.Id))
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
            ViewData["FornecedorId"] = new SelectList(_context.Set<FornecedorViewModel>(), "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: ProdutOs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ProdutoViewModel == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // POST: ProdutOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ProdutoViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProdutoViewModel'  is null.");
            }
            var produtoViewModel = await _context.ProdutoViewModel.FindAsync(id);
            if (produtoViewModel != null)
            {
                _context.ProdutoViewModel.Remove(produtoViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoViewModelExists(Guid id)
        {
          return _context.ProdutoViewModel.Any(e => e.Id == id);
        }
    }
}
