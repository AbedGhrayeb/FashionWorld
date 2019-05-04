using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionWorld.Data;
using FashionWorld.Models;
using FashionWorld.Models.ViewModels;
using FashionWorld.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FashionWorld.Controllers
{
    [Authorize]
    public class FavoritsController : Controller
    {
        private readonly IFavoritsRepository repository;
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext context;

        public FavoritsController(IFavoritsRepository repository,UserManager<AppUser> userManager,
            ApplicationDbContext context)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var favorits = repository.GetUserFavorites(userId);
           

         
            return View(favorits);
        }
       public IActionResult Add(int productId)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            Favorite favorite = new Favorite
            {
                ProductId = productId,
                AppUserId = userId
            };
            if (!FavoritExists(productId))
            {
                repository.AddToFavorits(favorite);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
          var favorite=  repository.GetFavorite(id);
           
            repository.RemoveFromFavorits(favorite);

            return RedirectToAction(nameof(Index));
        }

        private bool FavoritExists(int id)
        {
            return context.Favorites.Any(e => e.ProductId == id);
        }
    }
}