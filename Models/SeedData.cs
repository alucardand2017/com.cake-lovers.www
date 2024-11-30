using com.cake_lovers.www.Data;
using Microsoft.EntityFrameworkCore;

namespace com.cake_lovers.www.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CakeLoversDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<CakeLoversDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Produtos.Any())
            {
                context.Produtos.AddRange(
                    new Produto
                    {
                        NomeProduto = "Chocolate Silvestre",
                        Descricao = "Morango com cobertura de chocolate branco",
                        Categoria = "Premium",
                        Preco = 10,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/1.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Frankeinstein Belga",
                        Descricao = "Chocolate com cobertura de Pistache Silvestre",
                        Categoria = "Tematico",
                        Preco = 12,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/2.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Branca de Neve",
                        Descricao = "Chocolate com cobertura de amendoim",
                        Categoria = "Saudavel",
                        Preco = 15,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/3.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Chocolate com Leite",
                        Descricao = "Chocolate com leite com recheio de Abacaxi",
                        Categoria = "MaisVendido",
                        Preco = 12,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/4.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Floresta Negra",
                        Descricao = "Chocolate, morango com cobertura de amora",
                        Categoria = "Saudavel",
                        Preco = 10,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/5.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Brigadeiro",
                        Descricao = "Brigadeiro com cobertura de chocolate ao leite",
                        Categoria = "MaisVendido",
                        Preco = 10,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/6.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Amora Silvestre",
                        Descricao = "Amora com cobertura de chocolate branco cremoso",
                        Categoria = "Premium",
                        Preco = 15,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/7.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "torta de Limão",
                        Descricao = "Torta de limão com cobertura de granulados",
                        Categoria = "Tematico",
                        Preco = 12,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/8.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Leite Ninho",
                        Descricao = "Doce de leite ninho com cobertura de Ovo e Wey",
                        Categoria = "Saudavel",
                        Preco = 9,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/9.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Amora Silvestre",
                        Descricao = "Amora com cobertura de chocolate branco cremoso",
                        Categoria = "Premium",
                        Preco = 15,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/11.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Chocolate Black",
                        Descricao = "Chocolate com cobertura de granulados de chocolate",
                        Categoria = "Restricao",
                        Preco = 12,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/8.jpg"
                    },
                    new Produto
                    {
                        NomeProduto = "Serenata Urbana",
                        Descricao = "Queijo com cobertura de Ovo e Wey",
                        Categoria = "Promocao",
                        Preco = 9,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/3.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
