using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FashionWorld.Controllers
{
    [Authorize]
    public class ChatterController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}