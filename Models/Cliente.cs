namespace com.cake_lovers.www.Models
{
    public class Cliente
    {
        public int ClientId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}