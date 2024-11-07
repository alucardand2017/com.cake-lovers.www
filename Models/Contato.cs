namespace com.cake_lovers.www.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Mensagem { get; set; }
        public DateTime? Date { get; set; }
    }
}