namespace com.cake_lovers.www.Models
{
    public class MetodoPagamento
    {
        public int MetodoPagamentoId { get; set; }
        public string TipoMetodo { get; set; }
        public string Detalhes { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set;}
    }
}