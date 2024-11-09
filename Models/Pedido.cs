namespace com.cake_lovers.www.Models
{
    public class Pedido
    {
        public int? PedidoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public int? ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int? MetodoPagamentoId { get; set; }
        public virtual MetodoPagamento? MetodoPagamento { get; set; }
        public string? SituacaoPagamento { get; set; }
        public string? SituacaoEntrega { get; set; }
    }
}