using com.cake_lovers.www.Models;
using Microsoft.EntityFrameworkCore;

namespace com.cake_lovers.www.Data
{
    public class EFPedidoRepository : IPedidoRepository
    {
        private CakeLoversDbContext _context;

        public EFPedidoRepository(CakeLoversDbContext context)
        {
            _context = context;
        }

        public IQueryable<Pedido> Pedidos => _context.Pedidos
            .Include(o => o.LinhaDeProdutos)
            .ThenInclude(l => l.Produto);

        public void SalvarPedido(Pedido pedido)
        {
            _context.AttachRange(pedido.LinhaDeProdutos.Select(l => l.Produto));
            if (pedido.PedidoId == 0)
            {
                _context.Pedidos.Add(pedido);
            }
            _context.SaveChanges();
        }
    }
}
