using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace com.cake_lovers.www.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly ContatoService _contatoService;

        public ContatoController(ILogger<ContatoController> logger, ContatoService contatoService = null)
        {
            _logger = logger;
            _contatoService = contatoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contatos = _contatoService.GetAllContatos().ToList();
            var view = new ContatoModel()
            {
                Contatos = contatos
            };
            return View(view);
        }

        [HttpPost]
        public IActionResult AdicionaMensagemContato(ContatoModel contato)
        {
            try
            {
                _contatoService.AddContato(contato);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao adicionar contato. -> {e.Message} \n ->{e.StackTrace}");
            }
           
        }

        [HttpGet]
        public IActionResult DeletaContato(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var model = _contatoService.GetContatoPorId(id);
                    return View(model);
                }
                throw new ArgumentException($"Error = erro ao solicitar o produto para deletar");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }
        [HttpGet]
        public IActionResult ConfirmadoDelecao(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    _contatoService.DeletarContatoPorId(id);
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