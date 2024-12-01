namespace com.cake_lovers.www.Models.ModelView
{
    public class PedidoModel
    {
        public List<Pedido>? Pedidos { get; set; } = new List<Pedido>();
        public List<MetodoPagamento>? Pagamentos { get; set; } = new List<MetodoPagamento>();
    }
}
