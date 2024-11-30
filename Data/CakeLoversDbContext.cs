using com.cake_lovers.www.Models;
using Microsoft.EntityFrameworkCore;

namespace com.cake_lovers.www.Data
{
    public class CakeLoversDbContext : DbContext
    {
        public CakeLoversDbContext(DbContextOptions<CakeLoversDbContext> options)
           : base(options)
        {
        }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
