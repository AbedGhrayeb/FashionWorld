using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FashionWorld.Data;
using FashionWorld.Models;
using FashionWorld.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using FashionWorld.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FashionWorld.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly Cart cart;

        public CartController(ApplicationDbContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = context.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
      
        public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl)
        {
            Product product = context.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}