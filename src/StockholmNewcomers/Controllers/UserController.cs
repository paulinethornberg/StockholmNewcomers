using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StockholmNewcomers.Models.ViewModels;
using StockholmNewcomers.Models.Entities;
using StockholmNewcomers.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;
        DataManager dataManager;
        StockholmForNewcomersContext _context;

        public UserController(
            StockholmForNewcomersContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext dbContext)
        {
            dataManager = new DataManager(context, userManager);
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
            //_context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            //await _identityContext.Database.EnsureCreatedAsync();

            //Todo: add email when regestering. 

            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("UserName", result.Errors.First().Description);
                return View(model);
            }

            await _signInManager.PasswordSignInAsync(model.UserName, model.Password,
                false, false);

            return RedirectToAction(nameof(HomeController.Index), "home");
        }
    }
}
