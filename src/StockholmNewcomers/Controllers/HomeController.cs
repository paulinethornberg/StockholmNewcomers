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
            
            var organisations = dataManager.GetOrganisationsFromDB(); 

            return View(organisations);
        }

        public IActionResult AddOrganisation()
        {
          return View();
        }
        [HttpGet]
        public IActionResult AddMeetingPlace()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMeetingPlace(MeetingPlacesVM viewModel)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganisation(OrganisationsVM viewModel)
        {
            await dataManager.SaveOrganisationToDB(viewModel);

            return Content("The organisation will be reviewed and if accepted, the info will be added to the catalogue within a few days :) ");
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult MeetingPlaces()
        {
            //var meetingPlaces = dataManager.GetOrganisationsFromDB();
            var meetingPlaces = dataManager.GetMeetingPlacesFromDB();

            return View(meetingPlaces);
        }
    }
}
