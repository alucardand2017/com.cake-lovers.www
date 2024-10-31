namespace com.cake_lovers.www.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int MetodoPagamentoId { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}