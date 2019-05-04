using FashionWorld.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FashionWorld.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
       
        private readonly IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(
                x=>x.Category.CategoryName)
                .Distinct().OrderByDescending(x=>x));
        }
    }
}
