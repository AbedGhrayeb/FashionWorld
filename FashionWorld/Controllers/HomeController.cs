using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionWorld.Models;
using FashionWorld.Data;
using Microsoft.EntityFrameworkCore;
using FashionWorld.Repos;
using Microsoft.AspNetCore.Mvc.Rendering;
using FashionWorld.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Korzh.EasyQuery.Linq;
namespace FashionWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IProductRepository repo;
        public int pageSize = 4;
        public HomeController(ApplicationDbContext context, IProductRepository repo)
        {
            this.context = context;
            this.repo = repo;
        }
       
        public IActionResult Index() {
            ProductListVM model = new ProductListVM();
            return View(model);
        }
      
      [HttpPost]
            public IActionResult Search(string search,ProductListVM model)
        {
            return RedirectToAction("List", "Home", new { search = search , section = model.CurrentSection});
        }
        public IActionResult List(string category, string section, string search = null, int productPage = 1)
        {
            var product = repo.Products
              .Where(p => category == null || p.Category.CategoryName == category)
              .Where(p => section == null || p.Type == section)
                  .OrderBy(p => p.ProductID)
                  .Skip((productPage - 1) * pageSize)
                  .Take(pageSize);

            if (!String.IsNullOrEmpty(search))
            {
               
                product = repo.SearchProducts(search);
            }
            var pagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalItems = section == null ? (
                    category == null ?
                      repo.Products.Count() :
                      repo.Products.Where(e => e.Category.CategoryName == category).Count())
                      : repo.Products.Where(s => s.Type == section).Count()
            };
            IQueryable<string> querySection = context.Products.OrderBy(t => t.Type).Select(c => c.Type);
            var productListVM = new ProductListVM
            {
                Products = product,
                PagingInfo = pagingInfo,
                CurrentCategory = category,
                CurrentSection = product.Select(p => p.Type).ToString(),
                Section = new SelectList(querySection.Distinct().ToList()),
                SearchTerm = search
            };
            return View(productListVM);
        }
        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
                var product = await context.Products
                   .Include(c => c.Category).Include(p => p.Market)
                   .FirstOrDefaultAsync(m => m.ProductID == id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            
        }
        public async Task<IActionResult> MarketProducts(int id)
        {
            
                var product = await context.Products.Where(p => p.MarketId == id)
                .Include(c=>c.Category).ToListAsync();
                return View(product);
           
                
            
        }


        public IActionResult Contact()
{
    return View();
}       
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact contact){
            if (ModelState.IsValid)
            {
              context.Add(contact);
              await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            }
                return View(contact);
        }

        [Authorize]
        public IActionResult Offer()
        {
            var products = context.Products.Include(m=>m.Market).ToList();
            var offers = products.Exists(p => p.Discount > 0);
            if (offers)
            {

                return View(products.Where(p => p.Discount > 0));
            }
            else
            {
                return View("NoOffer");
            }
        }
      
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
