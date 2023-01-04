using Microsoft.AspNetCore.Mvc;
using Dev.AppMvc.ViewModels;
using Dev.Bussines.Interfaces;
using AutoMapper;
using MinhaAp.Busines.Models;

namespace Dev.AppMvc.Controllers
{
    public class ProdutOsController : BaseControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutOsController(IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }


        // GET: ProdutOs
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        // GET: ProdutOs/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
                
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        // GET: ProdutOs/Create
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);
            if (!ModelState.IsValid) return View(produtoViewModel);

            var imagemPrefixo = Guid.NewGuid() + "_";
            if (! await UploadDoArquivo(produtoViewModel.ImagemUplade, imagemPrefixo))
            {
                return View(produtoViewModel);
            }

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));
                    
            return View(produtoViewModel);
        }

        // GET: ProdutOs/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }            
            return View(produtoViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();
            
            if (!ModelState.IsValid) return View(produtoViewModel);
            
                await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction(nameof(Index));                                    
        }

        // GET: ProdutOs/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: ProdutOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            await _produtoRepository.Deletar(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutosPorFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());            
            return produto;
        }
        private async Task<bool> UploadDoArquivo(IFormFile arquivo, string imagePrefixo)
        {
            if(arquivo.Length <= 0 ) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagens", imagePrefixo + arquivo.FileName);

                if (System.IO.File.Exists(path))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome");
                    return false;
                }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            return true;
        }
    }
}
