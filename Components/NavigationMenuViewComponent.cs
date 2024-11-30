using com.cake_lovers.www.Data;
using Microsoft.AspNetCore.Mvc;

namespace com.cake_lovers.www.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private CakeLoversDbContext repository;
        public NavigationMenuViewComponent(CakeLoversDbContext repo)
        {
            repository = repo;
        }
        public async Task<IViewComponentResult> Invoke()
        {
           ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Produtos
            .Select(x => x.Categoria)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
