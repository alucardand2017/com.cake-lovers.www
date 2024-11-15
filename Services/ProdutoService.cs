using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using Microsoft.AspNetCore.Mvc;

namespace com.cake_lovers.www.Services
{
    public class ProdutoService
    {
        private readonly CakeLoversDbContext _context;

        public ProdutoService(CakeLoversDbContext context)
        {
            _context = context;
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
        public List<Produto> GetAllProdutos()
        {
            return _context.Produtos.ToList();
        }
        public List<Produto> GetAllProdutosCategoria(string termo)
        {
            return _context.Produtos.Where(p => p.Categoria == termo).ToList();
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
    }
}
