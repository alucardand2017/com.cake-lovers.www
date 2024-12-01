using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace com.cake_lovers.www.Models.ModelView
{
    public class ProdutoModel
    {
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        
        [BindProperty]
        public Produto NovoProduto { get; set; }

        [BindProperty]
        public IFormFile ProdutoImagem { get; set; }





    }
}
