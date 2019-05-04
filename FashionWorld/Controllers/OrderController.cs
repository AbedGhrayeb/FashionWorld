using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionWorld.Models;
using FashionWorld.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Order = FashionWorld.Models.Order;

namespace FashionWorld.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository repository;
        private readonly Cart cart;
        private readonly UserManager<AppUser> userManager;

        public OrderController(IOrderRepository repository,Cart cart,
            UserManager<AppUser> userManager)
        {

            this.repository = repository;
            this.cart = cart;
            this.userManager = userManager;
        }

        public ViewResult List()
        {
            if (User.IsInRole("Admins"))
            {
                return View(repository.Orders.Where(sh => !sh.Shipped));
            }
           
            else
            {
              var userId=  userManager.GetUserId(HttpContext.User);
                return View(repository.Orders.Where(u => u.UserId == userId));
            }

        }
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == id);
            if (order!=null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Checkout()
        {
            Order order = new Order();
            order.UserId = User.Identity.Name; /*userManager.GetUserId(HttpContext.User);*/

            order.DateCreated = DateTime.Now.Date;           
            return View(order);
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry Your Cart Is Empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines= cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }

        }
        public IActionResult Charge()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id,
                ReceiptEmail=stripeEmail,
                Metadata=new Dictionary<string, string>
                {
                    {"OrderId","111" },
                    {"PostCode","PL1223" }
                }
            });
            if (charge.Status=="Succeeded")
            {
                string balanceTransectionId = charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }
            return View();
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
     
    }
}