using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(ILogger<ContatoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? termo)
        {
            var view = new ContatoModel();
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