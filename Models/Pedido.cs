using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace com.cake_lovers.www.Models
{
    public class Pedido
    {
        [BindNever]
        [DisplayName("#")]

        public int PedidoId { get; set; }

        [DisplayName("Data")]
        public DateTime? DataPedido { get; set; }

        [DisplayName("Pago ?")]
        public string? SituacaoPagamento { get; set; }

        [DisplayName("Entregou ?")]
        public string? SituacaoEntrega { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Entre com um Nome válido!")]
        public string? NomeCompleto { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Entre com um Email válido!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DisplayName("Fone")]
        [Required(ErrorMessage = "Entre com um Telefone válido!")]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; }

        [DisplayName("Complem.")]
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