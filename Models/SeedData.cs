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
                        NomeProduto = "Morango Silvestre",
                        Descricao = "Morango com cobertura de chocolate branco",
                        Categoria = "Premium",
                        Preco = 10,
                        Estoque = 50,
                        ImagePath = "/Images/cupcakes/1.jpg"
                    },
                     new Produto
                     {
                         NomeProduto = "Chocolate Belga",
                         Descricao = "Chocolate com cobertura de Morango Silvestre",
                         Categoria = "Premium",
                         Preco = 12,
                         Estoque = 50,
                         ImagePath = "/Images/cupcakes/2.jpg"
                     },
                      new Produto
                      {
                          NomeProduto = "Pistache",
                          Descricao = "Pistache com cobertura de amendoim",
                          Categoria = "Saudavel",
                          Preco = 15,
                          Estoque = 50,
                          ImagePath = "/Images/cupcakes/3.jpg"
                      },
                       new Produto
                       {
                           NomeProduto = "Doce de Leite",
                           Descricao = "Doce de leite com cobertura de Abacaxi",
                           Categoria = "MaisVendido",
                           Preco = 12,
                           Estoque = 50,
                           ImagePath = "/Images/cupcakes/4.jpg"
                       },
                        new Produto
                        {
                            NomeProduto = "Laranja",
                            Descricao = "Laranja com cobertura de chocolate branco",
                            Categoria = "Saudavel",
                            Preco = 10,
                            Estoque = 50,
                            ImagePath = "/Images/cupcakes/5.jpg"
                        },
                         new Produto
                         {
                             NomeProduto = "Abacate",
                             Descricao = "Abacate com cobertura de chocolate ao leite",
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
                               NomeProduto = "Chocolate Black",
                               Descricao = "Chocolate com cobertura de Pistache",
                               Categoria = "Tematico",
                               Preco = 12,
                               Estoque = 50,
                               ImagePath = "/Images/cupcakes/8.jpg"
                           },
                            new Produto
                            {
                                NomeProduto = "Aveia Silvestre",
                                Descricao = "Aveia com cobertura de Ovo e Wey",
                                Categoria = "Saudavel",
                                Preco = 9,
                                Estoque = 50,
                                ImagePath = "/Images/cupcakes/9.jpg"
                            }
                );
                context.SaveChanges();
            }
        }
    }
}
