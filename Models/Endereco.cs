namespace com.cake_lovers.www.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public int ClientId { get; set; }
        public Cliente Cliente { get; set; }
    }
}