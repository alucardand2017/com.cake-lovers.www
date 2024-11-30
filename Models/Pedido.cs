using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace com.cake_lovers.www.Models
{
    public class Pedido
    {
        [BindNever]
        public int PedidoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public string? SituacaoPagamento { get; set; }
        public string? SituacaoEntrega { get; set; }

        [Required(ErrorMessage = "Entre com um Nome válido!")]
        public string? NomeCompleto { get; set; }

        [Required(ErrorMessage = "Entre com um Email válido!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Entre com um Telefone válido!")]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Entre com um Numero válido!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Entre com uma Rua válido!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Entre com um Bairro válido!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Entre com uma Cidade válida!")]
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Required(ErrorMessage = "Entre com um CEP válido!")]
        public string CEP { get; set; }
        public bool GiftWrap { get; set; }

        [BindNever]
        public virtual ICollection<CartLine> LinhaDeProdutos { get; set; } = new List<CartLine>();
    }
}