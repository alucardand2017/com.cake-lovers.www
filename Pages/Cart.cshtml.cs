using com.cake_lovers.www.Infrastructure;
using com.cake_lovers.www.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.cake_lovers.www.Data;

namespace com.cake_lovers.www.Pages
{
    public class CartModel : PageModel
    {
        private CakeLoversDbContext repository;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public CartModel(CakeLoversDbContext repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        //public IActionResult OnPost(long Id, string returnUrl)
        //{
        //    var product = repository.Produtos
        //    .FirstOrDefault(p => p.Id == Id);
        //    if (product != null)
        //    {
        //        Cart.AddItem(product,1);
        //    }
        //    return RedirectToPage(new { returnUrl = returnUrl });
        //}
        public IActionResult OnPost(long Id, string returnUrl)
        {
            var product = repository.Produtos.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long Id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Produto.Id == Id).Produto);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //    public IActionResult OnPost(long Id, string returnUrl)
        //    {
        //        if(  Id == 0)
        //        {
        //            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //            HttpContext.Session.SetJson("cart", Cart);
        //            return RedirectToPage(new { returnUrl = returnUrl });

        //        }
        //        var produto = repository.Produtos.FirstOrDefault(p => p.Id == Id);
        //        if (produto != null)
        //        {
        //            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //            Cart.AddItem(produto, 1);
        //            HttpContext.Session.SetJson("cart", Cart);
        //        }
        //        return RedirectToPage(new { returnUrl = returnUrl });
        //    }
        //}
    }
}