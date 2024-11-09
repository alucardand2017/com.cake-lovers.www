namespace com.cake_lovers.www.Models
{
    public class PedidoProduto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
    }
}