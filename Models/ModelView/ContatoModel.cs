using Castle.DynamicProxy;

namespace com.cake_lovers.www.Models.ModelView
{
    public class ContatoModel
    {
        public string Mensagem { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Enviado { get; set; }

    }
}
