using Microsoft.AspNetCore.Mvc;
using Dev.AppMvc.ViewModels;
using Dev.Bussines.Interfaces;
using AutoMapper;
using MinhaAp.Busines.Models;

namespace Dev.AppMvc.Controllers
{   
    public class FornecedoresController : BaseControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,IMapper mapper)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }
        [Route("lista-de-fornecedores")]
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<FornecedorViewModel>>( await _fornecedorRepository.ObterTodos()));
        }

        [Route("detalhes-de-fornecedores/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObeterFornecedorEndereco(id);
                
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("criar-fornecedor")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("criar-fornecedor")]
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

        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {            
            var fornecedorViewModel = await ObeterFornecedorProdutoEndereco(id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }

        [Route("editar-fornecedor/{id:guid}")]
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

        [Route("deletar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObeterFornecedorEndereco(id);
                
            if (fornecedorViewModel == null)  return NotFound();            

            return View(fornecedorViewModel);
        }

        [Route("deletar-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var fornecedorViewModel = await ObeterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return NotFound();

            await _fornecedorRepository.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObeterFornecedorEndereco(id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
            
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
