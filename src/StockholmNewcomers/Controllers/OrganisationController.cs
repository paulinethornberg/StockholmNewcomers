using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockholmNewcomers.Models;
using StockholmNewcomers.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class OrganisationController : Controller
    {
        // GET: /<controller>/
        DataManager dataManager;
        public OrganisationController(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager)
        {
            dataManager = new DataManager(context, userManager);
        }
        public IActionResult Index(int id)
        {
            //hämta från databasen
            var organisation = dataManager.GetOrganisationFromId(id);
            
            return View(organisation);
        }
    }
}
