using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;

namespace com.cake_lovers.www.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly CakeLoversDbContext _context;
        private readonly ProdutoService _produtoService;
        private readonly Cart cart;


        public ProdutoController(ILogger<ProdutoController> logger, CakeLoversDbContext produtoService, Cart cart, ProdutoService produto)
        {
            _produtoService = produto;
            _logger = logger;
            _context = produtoService;
            this.cart = cart;
        }
        [HttpGet]
        public IActionResult Index(string? termo)
        {
            try
            {
                var produtos = _produtoService.GetAllProdutos();
                var view = new ProdutoModel { Produtos = produtos, NovoProduto = new Produto() };
                return View(view);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro = {e.Message} + \n Trace = {e.StackTrace}");
            }
        }

        [HttpGet]
        public ViewResult EscolherProdutos(string? category, int productPage = 1)
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

        [HttpGet]
        public ViewResult Checkout() => View(new Pedido());

        [HttpPost]
        public IActionResult AdicionaMensagemContato(Contato contato)
        {
            try
            {
                var resultado = _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToPage("/Agradecimento");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao adicionar contato. -> {e.Message} \n ->{e.StackTrace}");
            }

        }

        [HttpPost]
        public IActionResult Checkout(Pedido order)
        {

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Desculpe, O carrinho está vazio!");
            }
            if (ModelState.IsValid)
            {
                order.LinhaDeProdutos = cart.Lines.ToArray();
                _produtoService.SalvarPedido(order);
                cart.Clear();
                return RedirectToPage("/ConclusaoPedido", new { PedidoId = order.PedidoId });
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}