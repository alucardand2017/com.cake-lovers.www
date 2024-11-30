using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;

namespace com.cake_lovers.www.Services
{
    public class PedidoService
    {
        private readonly CakeLoversDbContext _context;

        public PedidoService(CakeLoversDbContext context)
        {
            _context = context;
        }

    }
}
