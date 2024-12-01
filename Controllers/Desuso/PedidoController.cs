using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers.Desuso
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository repository;
        private readonly Cart cart;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger, IPedidoRepository repository, Cart cart)
        {
            _logger = logger;
            this.repository = repository;
            this.cart = cart;
        }

        [HttpGet]
        public IActionResult GettAllPedidos()
        {

            return View(new PedidoModel
            {
                Pedidos = repository.Pedidos.ToList(),
            });
        }

        [HttpGet]
        public ViewResult Checkout() => View(new Pedido());

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
                repository.SalvarPedido(order);
                cart.Clear();
                return RedirectToPage("/ConclusaoPedido", new { order.PedidoId });
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