using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? termo)
        {
            var view = new ClienteModelView();
            return View(view);
        }
        public IActionResult GetAllProdutos()
        {
            return View();
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