using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionWorld.Data;
using FashionWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FashionWorld.Controllers
{
    [Authorize(Roles = "Admins,Market Owner")]
    public class MarketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _UserManager;

        public MarketsController(ApplicationDbContext context, UserManager<AppUser> _userManager)
        {
            _context = context;
            _UserManager = _userManager;
        }

        // GET: Markets
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Market Owner"))
            {
                var userId = _UserManager.GetUserId(HttpContext.User);

                var markets =await _context.Markets.Where(m => m.AppUserId == userId).ToListAsync();


                return View(markets);
            }
            else
            {


                return View(await _context.Markets.ToListAsync());
            }
        }


        // GET: Markets/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("MarketID,MarketName,Descripshion,MarketOwner,MarketAddress,FBUrl,Images")] Market market)
        {
            if (ModelState.IsValid)
            {
                var userId = _UserManager.GetUserId(HttpContext.User);
                market.AppUserId = userId;
                _context.Add(market);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(market);
        }

        // GET: Markets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _UserManager.GetUserId(HttpContext.User);
            var market = await _context.Markets.FindAsync(id);
            if (!market.AppUserId.Equals(userId))
            {
                return Content("You are not authorized to do this action");
            }
            if (market == null)
            {
                return NotFound();
            }
            return View(market);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarketID,MarketName,Descripshion,MarketOwner,MarketAddress,FBUrl,Images")] Market market)
        {
            if (id != market.MarketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(market);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketExists(market.MarketID))
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
            return View(market);
        }

        // GET: Markets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _UserManager.GetUserId(HttpContext.User);
            var market = await _context.Markets.FirstOrDefaultAsync(m => m.MarketID == id);
            if (!market.AppUserId.Equals(userId))
            {
                return Content("You are not authorized to do this action");
            }
            
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var market = await _context.Markets.FindAsync(id);
            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        private bool MarketExists(int id)
        {
            return _context.Markets.Any(e => e.MarketID == id);
        }
    }
}
