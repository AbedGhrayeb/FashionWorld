using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionWorld.Data;
using FashionWorld.Models;
using System.IO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FashionWorld.Controllers
{

    [Authorize(Roles = "Admins,Market Owner")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment appEnvironment;
        private readonly UserManager<AppUser> _UserManager;

        public ProductsController(ApplicationDbContext context, IHostingEnvironment appEnvironment,
            UserManager<AppUser> _userManager)
        {
            _context = context;
            this.appEnvironment = appEnvironment;
            _UserManager = _userManager;
        }

        // GET: Products
        public IActionResult Index()
        {

            if (User.IsInRole("Market Owner"))
            {
                var userId = _UserManager.GetUserId(HttpContext.User);

                var market = _context.Markets.FirstOrDefault(m => m.AppUserId == userId);

                var products = _context.Products
            .Include(c => c.Category).Where(p => p.Market.MarketID == market.MarketID).ToList();
                return View(products);
            }
            else {
                var products = _context.Products.Include(p => p.Market)
                .Include(c => c.Category).ToList();
                return View(products);
            }


        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Market Owner"))
            {
                var userId = _UserManager.GetUserId(HttpContext.User);

                var market = _context.Markets.FirstOrDefault(m => m.AppUserId == userId);

                var product = await _context.Products
                .Include(c => c.Category).Where(p => p.Market.MarketID == market.MarketID)
                .FirstOrDefaultAsync(m => m.ProductID == id);
                return View(product);
            }
            else
            {
                var product = await _context.Products
                   .Include(c => c.Category).Include(p => p.Market)
                   .FirstOrDefaultAsync(m => m.ProductID == id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
        }



        // GET: Products/Create
        public IActionResult Create()
        {
            var userId = _UserManager.GetUserId(HttpContext.User);

            var market = _context.Markets.FirstOrDefault(m => m.AppUserId == userId);
            if (User.IsInRole("Market Owner"))
            {


                if (market == null)
                {
                    return NotFound();
                }
                if (market.AppUserId.Equals(userId))
                {
                    ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName", market.MarketID);

                    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");

                    return View(new Product { DateAdded = DateTime.Now.Date, MarketId = market.MarketID });
                }
            }


            ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName");

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");

            return View(new Product { DateAdded = DateTime.Now.Date });

        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {

            if (ModelState.IsValid)
            {
                var discountValue = this.CalculateDiscountValue(product.Price, product.Discount);
                var newPrice = this.NewPriceCalculate(product.Price, discountValue);
                product.SalePrice = newPrice;
                UploadImages(product);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }


            ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName", product.MarketId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryId);

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.Include(m => m.Market)
                .Include(c => c.Category)
          .FirstOrDefaultAsync(m => m.ProductID == id);

            if (User.IsInRole("Market Owner"))
            {
                var userId = _UserManager.GetUserId(HttpContext.User);
                var marketUserId = product.Market.AppUserId;
                var market = await _context.Markets.FirstOrDefaultAsync(m => m.AppUserId == userId);
                if (!marketUserId.Equals(userId))
                {
                    return Content("You are not authorized to do this action");
                }
                else
                {
                   
                    ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName", market.MarketID);
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
                    return View(product);
                }

            }

            
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName");
                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
                return View(product);
            }
        }


    // POST: Products/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.ProductID)
        {
            return NotFound();
        }

            if (ModelState.IsValid)
            {
         
                try
                {
                   // var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == offer.ProductId);
                    var discountValue = this.CalculateDiscountValue(product.Price, product.Discount);
                    var newPrice = this.NewPriceCalculate(product.Price, discountValue);
                    product.SalePrice= newPrice;
                    UploadImages(product);
                    _context.Update(product);
                   await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }

            ViewData["MarketId"] = new SelectList(_context.Markets, "MarketID", "MarketName", product.ProductID);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryId);
            return View(product);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .Include(p => p.Market).Include(c=>c.Category)
            .FirstOrDefaultAsync(m => m.ProductID == id);
        if (product == null)
        {
            return NotFound();
        }
            if (User.IsInRole("Market Owner"))
            {
                var userId = _UserManager.GetUserId(HttpContext.User);
                var marketUserId = product.Market.AppUserId;
                if (!marketUserId.Equals(userId))
                {
                    return Content("You are not authorized to do this action");
                }
                return View(product);
            }
            return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.ProductID == id);
    }
         
     
      
     
        protected decimal CalculateDiscountValue(decimal salesPrice, decimal discountPercentage)
        {
            return salesPrice * discountPercentage / 100m;
        }

        protected decimal NewPriceCalculate(decimal salesPrice, decimal discountAmount)
        {
            return salesPrice - discountAmount;
        }
        public void UploadImages(Product product)
        {
            
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploads = Path.Combine(appEnvironment.WebRootPath, "images/products");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            product.ImageUrl=fileName;

                        }
                    }
                }
            }
        }

       
    }
}


