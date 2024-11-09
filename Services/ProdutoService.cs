using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;

namespace com.cake_lovers.www.Services
{
    public class ProdutoService 
    {
        private readonly CakeLoversDbContext _context;

        public ProdutoService(CakeLoversDbContext context)
        {
            _context = context;
        }

        public List<Produto> GetAllProdutos()
        {
          return _context.Produtos.ToList();
        }
    }
}
