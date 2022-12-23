using Microsoft.AspNetCore.Mvc;
using Dev.AppMvc.ViewModels;
using Dev.Bussines.Interfaces;
using AutoMapper;
using MinhaAp.Busines.Models;

namespace Dev.AppMvc.Controllers
{   
    public class FornecedoresViewModelsController : BaseControllerBase
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

        
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObeterFornecedorEndereco(id);
                
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
        public async Task<IActionResult> Create( FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            _fornecedorRepository.Adicionar(fornecedor);
                return RedirectToAction(nameof(Index));
            
            return View(fornecedorViewModel);
        }

        
        public async Task<IActionResult> Edit(Guid id)
        {            
            var fornecedorViewModel = await ObeterFornecedorProdutoEndereco(id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) View(fornecedorViewModel);
                            
                

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Atualizar(fornecedor);

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObeterFornecedorEndereco(id);
                
            if (fornecedorViewModel == null)  return NotFound();            

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var fornecedorViewModel = await ObeterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return NotFound();

            await _fornecedorRepository.Deletar(id);

            return RedirectToAction(nameof(Index));
        }       
        private async Task<FornecedorViewModel> ObeterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
        private async Task<FornecedorViewModel> ObeterFornecedorProdutoEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
