using com.cake_lovers.www.Models;

namespace com.cake_lovers.www.Data
{
    public interface IPedidoRepository
    {
        IQueryable<Pedido> Pedidos { get; }
        void SalvarPedido(Pedido order);
    }

}
