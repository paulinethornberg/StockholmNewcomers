using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockholmNewcomers.Models;
using StockholmNewcomers.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StockholmNewcomers.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class HomeController : Controller
    {
        DataManager dataManager;
        public HomeController(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager)
        {
            dataManager = new DataManager(context, userManager);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            var homePagevM = dataManager.GetOrganisationsFromDB(); 

            return View(homePagevM);
        }
       
        public IActionResult About()
        {
            return View();
        }


    }
}
