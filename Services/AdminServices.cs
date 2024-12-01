﻿using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;

namespace com.cake_lovers.www.Services
{
    public class AdminServices
    {
        private readonly CakeLoversDbContext _context;

        public AdminServices(CakeLoversDbContext context)
        {
            _context = context;
        }
        public int AddContato(ContatoModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Não há dados para adicionar um contato");
            }
            var contato = new Contato()
            {
                Mensagem= model.Mensagem,
                Nome= model.Nome,
                Date= DateTime.Now,
                Email= model.Email,
            };
            _context.Contatos.Add(contato);
            return _context.SaveChanges();
        }
        public List<Contato> GetAllContatos()
        {
            return _context.Contatos.ToList();
        }
        public Contato GetContatoPorId(int id)
        {
            if (id > 0)
            {
                return _context.Contatos.FirstOrDefault(p => p.ContatoId == id);
            }
            throw new ArgumentNullException("Não foi possível encontrar o contato solicitado");
        }
        public void DeletarContatoPorId(int? id)
        {
            var contato = _context.Contatos.FirstOrDefault(predicate => predicate.ContatoId == id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                _context.SaveChanges();
            }

        }
        public async Task<Produto> AddProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("Não há dados para adicionar um produto");
            }
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public IQueryable<Produto> GetAllProdutos()
        {
            return _context.Produtos;
        }
        public List<Produto> GetAllProdutosCategoria(string termo)
        {
            return _context.Produtos.Where(p => p.Categoria == termo || p.Categoria == null).ToList();
        }
        public Produto GetAllProdutosForId(int? id)
        {
            if (id.HasValue)
            {

                return _context.Produtos.FirstOrDefault(p => p.Id == id);
            }
            throw new ArgumentNullException("Não foi possível encontrar o produto solicitado");
        }
        public Produto UpdateProduto(Produto produtoAtualizado)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == produtoAtualizado.Id);
            if (produto != null)
            {
                produto.NomeProduto = produtoAtualizado.NomeProduto;
                produto.Preco = produtoAtualizado.Preco;
                produto.Estoque = produtoAtualizado.Estoque;
                produto.Categoria = produtoAtualizado.Categoria;
                produto.ImagePath = produtoAtualizado.ImagePath;
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return produtoAtualizado;
            }
            throw new ArgumentNullException("Não foi possível encontrar o produto solicitado");
        }
        public void DeletarProdutoPorId(int? id)
        {
            var produto = _context.Produtos.FirstOrDefault(predicate => predicate.Id == id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }

        }

        public IQueryable<Pedido> GetAllPedidos()
        {
            return _context.Pedidos;
        }

        public Pedido GetPedidoPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);
        }

        public void DeletarPedidoPorId(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(predicate => predicate.PedidoId == id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }
    }
}
