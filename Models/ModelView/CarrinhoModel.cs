namespace com.cake_lovers.www.Models.ModelView
{
    public class CarrinhoModel
    {
        public IEnumerable<Produto> Produtos { get; set; }  = Enumerable.Empty<Produto>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}
