using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly ILogger<CarrinhoController> _logger;

        public CarrinhoController(ILogger<CarrinhoController> logger, ProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        public IActionResult Index(string? termo)
        {
            var view = new CarrinhoModel();
            return View(view);
        }
        [HttpGet]
        public IActionResult GetAllProdutos(string? termo)
        {
            if(termo== null)
            {
                var produtos = _produtoService.GetAllProdutos();
                CarrinhoModel carrinho = new()
                {
                    Produtos = produtos,
                };
                return View(carrinho);
            }
            else
            {

            }
            var view = new CarrinhoModel();
            return View(view);
        }
        public IActionResult GetByIdProdutos(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}