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
        private readonly IProdutoService _produtoService;
        public ProdutOsController(IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper,
            IProdutoService produtoService,INotificador notificador):base(notificador)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _produtoService = produtoService;
        }


        [Route("listar-Produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        [Route("detalhes-Produtos/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
                
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        [Route("criar-Produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [Route("criar-Produto")]
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
            produtoViewModel.Imagem = imagemPrefixo + produtoViewModel.ImagemUplade.FileName;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
            if (!OperacaoValida()) return View(produtoViewModel);
            
            return RedirectToAction(nameof(Index));
        }

        [Route("editar-Produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }            
            return View(produtoViewModel);
        }

        [Route("editar-Produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoViewModelAtualizacao = await ObterProduto(id);
            produtoViewModel.Fornecedor = produtoViewModelAtualizacao.Fornecedor;

            produtoViewModel.Imagem = produtoViewModelAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUplade != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadDoArquivo(produtoViewModel.ImagemUplade,imgPrefixo))
                {
                    return View(produtoViewModel);
                }
                produtoViewModelAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUplade.FileName;
            }
            produtoViewModelAtualizacao.Nome = produtoViewModel.Nome;
            produtoViewModelAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoViewModelAtualizacao.Valor = produtoViewModel.Valor;
            produtoViewModelAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModelAtualizacao));
            if (!OperacaoValida()) return View(produtoViewModel);
            return RedirectToAction(nameof(Index));                                    
        }

        [Route("excluir-Produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [Route("excluir-Produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            await _produtoService.Remover(id);
            if (!OperacaoValida()) return View(produto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
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
