namespace com.cake_lovers.www.Models
{
    public class MetodoPagamento
    {
        public int MetodoPagamentoId { get; set; }
        public string TipoMetodo { get; set; }
        public string Detalhes { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}