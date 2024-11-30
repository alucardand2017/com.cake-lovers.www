namespace com.cake_lovers.www.Models
{
    public class Pedido
    {
        public int? PedidoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public int? MetodoPagamentoId { get; set; }
        public virtual MetodoPagamento? MetodoPagamento { get; set; }
        public string? SituacaoPagamento { get; set; }
        public string? SituacaoEntrega { get; set; }

        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public bool GiftWrap { get; set; }
    }
}