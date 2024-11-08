﻿using com.cake_lovers.www.Models;
using Microsoft.EntityFrameworkCore;

namespace com.cake_lovers.www.Data
{
    public class CakeLoversDbContext : DbContext
    {
        public CakeLoversDbContext(DbContextOptions<CakeLoversDbContext> options)
           : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamentos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
    }
}
