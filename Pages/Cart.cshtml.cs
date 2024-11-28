using com.cake_lovers.www.Infrastructure;
using com.cake_lovers.www.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.cake_lovers.www.Data;

namespace com.cake_lovers.www.Pages
{
    public class CartModel : PageModel
    {
        private  CakeLoversDbContext repository;
        public CartModel(CakeLoversDbContext repo)
        {
            repository = repo;
        }
        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        
        
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            var produto = repository.Produtos.FirstOrDefault(p => p.Id == productId);
            if (produto != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(produto, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}