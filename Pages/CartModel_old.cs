using com.cake_lovers.www.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using com.cake_lovers.www.Data;
using com.cake_lovers.www.Infrastructure;


namespace SportsStore.Pages
{
    public class CartModel_old : PageModel
    {
        private CakeLoversDbContext repository;
        public CartModel_old(CakeLoversDbContext repo)
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
            Produto? product = repository.Produtos
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
