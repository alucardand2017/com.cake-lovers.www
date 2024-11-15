namespace com.cake_lovers.www.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
