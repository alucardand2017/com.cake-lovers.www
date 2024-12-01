using com.cake_lovers.www.Models;

namespace com.cake_lovers.www.Data
{
    public class EFProdutoRepository : IProdutoRepository
    {
        private readonly CakeLoversDbContext _context;
        public EFProdutoRepository(CakeLoversDbContext context)
        {
            _context = context;
        }
        public IQueryable<Produto> Produtos => _context.Produtos;
    }
}
