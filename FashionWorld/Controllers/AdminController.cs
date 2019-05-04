using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FashionWorld.Data;
using FashionWorld.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace FashionWorld.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private readonly ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleMgr, UserManager<AppUser> usrMgr,ApplicationDbContext context)
        {
            userManager = usrMgr;
            this.context = context;
            roleManager = roleMgr;
        }
        [AllowAnonymous]
        public IActionResult Welcome() => View();
        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    TempData["message"] = $"{user.UserName} has been Added";
                    return RedirectToAction("Index", userManager.Users);
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = $"{user.UserName} has been deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", userManager.Users);
        }


        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", userManager.Users);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email,
        string password, string username)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.UserName = username;
                user.Email = email;
                user.PasswordHash = password;



                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = $"{user.UserName} has been updated";
                    return RedirectToAction("Index", userManager.Users);
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }



     public IActionResult ContactList()
        {
            return View(context.Contacts.ToList());
        }

        public async Task<IActionResult> ContactDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await context.Contacts
               
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        public IActionResult DeleteContactMessage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = context.Contacts
                .FirstOrDefault(m => m.ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
                [HttpPost, ActionName("DeleteContactMessage")]
[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContactMessageConfirm(int? id)
        {
            var contact = context.Contacts.FirstOrDefault(m=>m.ID==id);
          
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(ContactList));
            
      
        }
        public async Task<IActionResult> ReplayMessage(int id)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(c => c.ID == id);
            Contact sendContact = new Contact()
            {
                Name = "Fashion World Replay",
            Email = "fashionworld@gmail.com",
            Supject = "Admin Replay for " + contact.Supject
        };
            return View(sendContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReplayMessage(int id,Contact sendContact)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(c => c.ID == id);
            var msg= new MimeMessage();
            msg.From.Add(new MailboxAddress("fashionworld replay", "fashionworld@gmail.com"));
            msg.To.Add(new MailboxAddress(contact.Name,contact.Email));
            msg.Subject = (contact.Supject);
            msg.Body = new TextPart(sendContact.Message);

        
           

            using(var client=new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("fashionworld@gmail.com", "");
                client.Send(msg);
                client.Disconnect(true);
            }
           
            return View();
        }
     
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }

}

