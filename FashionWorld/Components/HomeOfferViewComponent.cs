using FashionWorld.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Components
{
    public class HomeOfferViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public HomeOfferViewComponent(ApplicationDbContext context)
        {
   
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            var products = context.Products.Include(m => m.Market).ToList();
            var offers = products.Exists(p => p.Discount > 0);
            if (offers)
            {

                return View(products.Where(p => p.Discount > 0).Take(6));
            }
            else
            {
                return View("NoOffer");
            }
        }
    }
}
