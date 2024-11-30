using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CakeLoversDbContext _context;
        private readonly ILogger<CarrinhoController> _logger;

        public CarrinhoController(ILogger<CarrinhoController> logger, CakeLoversDbContext produtoService)
        {
            _logger = logger;
            _context = produtoService;
        }

        public IActionResult Index()
        {
            var view = new CarrinhoModel();
            return View(view);
        }
        [HttpGet]
        public ViewResult GetAllProdutos(string? category, int productPage = 1)
        => View(new CarrinhoModel
        {
            Produtos = _context.Produtos
                    .Where(p => category == null || p.Categoria == category)
                   .OrderBy(p => p.Id),

            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                TotalItems = category == null
                        ? _context.Produtos.Count()
                        : _context.Produtos.Where(e =>
                            e.Categoria == category).Count()
            },
            CurrentCategory = category
        });
        //TempData["category"] = category;
        //if(category == null)
        //{
        //    var produtos = _produtoService.GetAllProdutos();
        //    CarrinhoModel carrinho = new()
        //    {
        //        Produtos = produtos,
        //    };
        //    return View(carrinho);
        //}
        //else
        //{
        //    var produtos = _produtoService.GetAllProdutosCategoria(category);
        //    PagingInfo pagina = new PagingInfo
        //    {
        //        CurrentPage = productPage,
        //        ItemsPerPage = 100,
        //        TotalItems = category == null ? _produtoService
        //        .GetAllProdutos().Count() : _produtoService.GetAllProdutos()
        //        .Where(e => e.Categoria == category).Count()
        //    };
        //    CarrinhoModel carrinho = new()
        //    {
        //        Produtos = produtos,
        //        CurrentCategory = category,
        //        PagingInfo= pagina
        //    };
        //    return View(carrinho);
        //}
        public IActionResult GetByIdProdutos(int id)
        {
            return View();
        }

        public IActionResult MetodoPagamento()
        {
            var metodo = new MetodoPagamento();
            return View(metodo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}