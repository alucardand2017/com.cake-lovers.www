using com.cake_lovers.www.Data;
using Microsoft.AspNetCore.Mvc;
using com.cake_lovers.www.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace com.cake_lovers.www.Components
{
    public class NavigationMenuViewComponent
    {
        private CakeLoversDbContext repository;
        public NavigationMenuViewComponent(CakeLoversDbContext repo)
        {
            repository = repo;
        }
        public List<string> Invoke()
        {
            //ViewBag.SelectedCategory = RouteData?.Values["category"];
            return repository.Produtos
            .Select(x => x.Categoria)
            .Distinct()
            .OrderBy(x => x).ToList();
        }
    }
}
