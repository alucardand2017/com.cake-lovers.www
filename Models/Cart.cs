
namespace com.cake_lovers.www.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Produto produto, int quantidade)
        {
            CartLine? line = Lines
            .Where(p => p.Produto.Id == produto.Id)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                line.Quantidade += quantidade;
            }
        }
        public virtual void RemoveLine(Produto produto) => Lines.RemoveAll(l => l.Produto.Id == produto.Id);
        public decimal ComputeTotalValue() => Lines.Sum(e => e.Produto.Preco * e.Quantidade);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Produto Produto { get; set; } = new();
        public int Quantidade { get; set; }
    }
}
