using com.cake_lovers.www.Data;
using Microsoft.EntityFrameworkCore;

namespace com.cake_lovers.www.Services
{
    public class ProdutoService 
    {
        private readonly CakeLoversDbContext _context;

        public ProdutoService(CakeLoversDbContext context)
        {
            _context = context;
        }
    }
}
