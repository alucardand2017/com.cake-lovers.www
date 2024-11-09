namespace com.cake_lovers.www.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        //public List<PedidoProduto> PedidoProdutos { get; set; }
        public string CaminhoFoto { get; set; }
    }
}
