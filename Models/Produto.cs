using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace com.cake_lovers.www.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        [Range(0.01, 1000000, ErrorMessage = "O preço deve ser positivo.")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; set; }
        public string ImagePath { get; set; }
    }
}
