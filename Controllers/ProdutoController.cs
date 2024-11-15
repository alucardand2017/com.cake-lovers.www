using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace com.cake_lovers.www.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, ProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }
        [HttpGet]
        public IActionResult Index(string? termo)
        {
            try
            {
                var produtos = _produtoService.GetAllProdutos();
                var view = new ProdutoEscolhaModelView { Produtos = produtos, NovoProduto = new Produto() };
                return View(view);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro = {e.Message} + \n Trace = {e.StackTrace}");
            }
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            try
            {
                var produtos = _produtoService.GetAllProdutos();
                return View(produtos);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro = {e.Message} + \n Trace = {e.StackTrace}");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionaProduto(ProdutoEscolhaModelView model)
        {
            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("NovoProduto.ImagePath");

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                if (model.ProdutoImagem != null)
                {
                    var uploadsFolder = Path.Combine("wwwroot", "images");
                    var uniqueFileName = $"{Guid.NewGuid()}_{model.ProdutoImagem.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProdutoImagem.CopyToAsync(fileStream);
                    }

                    model.NovoProduto.ImagePath = $"/images/{uniqueFileName}";
                    //decimal.TryParse(model.NovoProduto.Preco.ToString("C"), NumberStyles.Any, new CultureInfo("pt-BR"), out decimal valor);
                    //model.NovoProduto.Preco = valor;
                    await _produtoService.AddProduto(model.NovoProduto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                throw new ArgumentException($"Error = {e.Message}");
            }

        }

        [HttpGet]
        public IActionResult SolicitaDelecaoProduto(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var produto = _produtoService.GetAllProdutosForId(id);
                    return View(produto);
                }
                throw new ArgumentException($"Error = erro ao solicitar o produto para deletar");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }

        [HttpGet]
        public IActionResult UpdateProdutoPorId(int? id)
        {
            throw new ArgumentException();
        }

        [HttpPost]
        public IActionResult UpdateProduto(Produto produto)
        {
            _produtoService.UpdateProduto(produto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult DeletarProduto(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                     _produtoService.DeletarProdutoPorId(id);
                    return RedirectToAction(nameof(Index));
                }
                throw new ArgumentException($"Error = não tem id para deleção");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}