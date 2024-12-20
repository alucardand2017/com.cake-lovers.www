﻿using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;
using com.cake_lovers.www.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace com.cake_lovers.www.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly AdminServices _adminService;
        private readonly ProdutoService _produtoService;


        public AdminController(ILogger<AdminController> logger, AdminServices contatoService = null, ProdutoService produtoService = null)
        {
            _logger = logger;
            _adminService = contatoService;
            _produtoService = produtoService;
        }



        [HttpGet]
        public IActionResult GetAllPedidos()
        {
            var pedidos = _adminService.GetAllPedidos().ToList();
            var model = new PedidoModel()
            {
                Pedidos = pedidos,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult VisualizaPedido(int id)
        {
            var pedido = _adminService.GetPedidoPorId(id);
            return View(pedido);
        }
        [HttpGet]
        public IActionResult DeletaPedido(int id)
        {
            try
            {
                var pedido = _adminService.GetPedidoPorId(id);
                return View(pedido);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }
        [HttpPost]
        public IActionResult DeletarPedido(int PedidoId)
        {
            try
            {
                if (PedidoId > 0)
                {
                    _adminService.DeletarPedidoPorId(PedidoId);
                    return RedirectToAction(nameof(GetAllPedidos));
                }
                throw new ArgumentException($"Error = não tem id para deleção");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }
        [HttpGet]
        public IActionResult UpdatePedido(int id)
        {
            var pedido = _adminService.GetPedidoPorId(id);
            return View(pedido);
        }
        [HttpPost]
        public IActionResult UpdatePedido(Pedido pedido)
        {
            _adminService.UpdatePedido(pedido);
            return RedirectToAction(nameof(GetAllPedidos));
        }



        [HttpGet]
        public IActionResult GetAllContatos()
        {
            var list = _adminService.GetAllContatos().ToList();
            var model = new ContatoModel()
            {
                Contatos = list
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult DeletaContato(int id)
        {
            try
            {
                var model = _adminService.GetContatoPorId(id);
                return View(model);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }
        [HttpPost]
        public IActionResult DeletarContato(int? ContatoId)
        {
            try
            {
                if (ContatoId.HasValue)
                {
                    _adminService.DeletarContatoPorId(ContatoId);
                    return RedirectToAction(nameof(GetAllContatos));
                }
                throw new ArgumentException($"Error = não tem id para deleção");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error = {e.Message}");
            }
        }


        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            var list = _adminService.GetAllProdutos().ToList();
            var model = new ProdutoModel()
            {
            Produtos = list
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AdicionaProduto(ProdutoModel model)
        {
            try
            {
                if (model.NovoProduto.Id > 0)
                {
                    _adminService.UpdateProduto(model.NovoProduto);
                    return RedirectToAction(nameof(GetAllProdutos));
                }
                ModelState.Remove("Id");
                ModelState.Remove("NovoProduto.ImagePath");
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(GetAllProdutos));
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
                    await _produtoService.AddProduto(model.NovoProduto);
                }
                return RedirectToAction(nameof(GetAllProdutos));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro durante a ação de adicionar produtos = {e.Message}");
            }
        }
        [HttpGet]
        public IActionResult UpdateProduto(int id)
        {
            var produto = _adminService.GetProdutosPorId(id);
            return View(produto);
        }
        [HttpPost]
        public IActionResult UpdateProduto(Produto produto)
        {
            produto.Preco = Convert.ToDecimal(Request.Form["Preco"].ToString().Replace(".", "").Replace(",", "."));
            _adminService.UpdateProduto(produto);
            return RedirectToAction(nameof(GetAllProdutos));
        }
        [HttpGet]
        public IActionResult DeletaProduto(int? id)
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
        [HttpPost]
        public IActionResult DeletarProduto(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    _produtoService.DeletarProdutoPorId(Id);
                    return RedirectToAction(nameof(GetAllProdutos));
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