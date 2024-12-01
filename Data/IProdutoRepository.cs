using com.cake_lovers.www.Models;

namespace com.cake_lovers.www.Data
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> Produtos { get; }
    }
}
