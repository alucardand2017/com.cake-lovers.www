using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SobreNos()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contato(int idTemp)
        {
            var data = ViewBag.Data; // Recebe o valor do primeiro controlador

            var contato = new ContatoModel()
            {
                Email = string.Empty,
                Enviado = false,
                Nome = string.Empty,
                Mensagem = string.Empty,
            };
           if (idTemp > 0)
            {
                contato.Enviado = true;
            }
           else
            {
                contato.Enviado = false;
            }
            return View(contato);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}