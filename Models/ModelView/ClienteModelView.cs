namespace com.cake_lovers.www.Models.ModelView
{
    public class ClienteModelView
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Cliente NovoCliente { get; set; }
        public Endereco NovoEndereco { get; set; }
    }
}
