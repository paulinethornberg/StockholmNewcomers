using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockholmNewcomers.Models.ViewModels;
using StockholmNewcomers.Models;
using StockholmNewcomers.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class MeetingPlaceController : Controller
    {
        // GET: /<controller>/
        DataManager dataManager;
        public MeetingPlaceController(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager)
        {
            dataManager = new DataManager(context, userManager);
        }

        public IActionResult Index(int id)
        {
            //hämta från databasen
            var meetingPlace = dataManager.GetMeetingPlaceFromId(id);

            return View(meetingPlace);
        }

        public IActionResult MeetingPlaces()
        {
            //var meetingPlaces = dataManager.GetOrganisationsFromDB();
            var meetingPlaces = dataManager.GetMeetingPlacesFromDB();

            return View(meetingPlaces);
        }

        [HttpGet]
        public IActionResult AddMeetingPlace(MeetingPlacesVM viewModel)
        {
            var tags = dataManager.GetTagsFromDB();
            AddMeetingPlaceVM addMPVM = new AddMeetingPlaceVM();
            addMPVM.Tags = tags;
            return View(addMPVM);

        }
        [HttpPost]
        public IActionResult AddMeetingPlace(AddMeetingPlaceVM viewModel)
        {
            dataManager.SaveMeetingPlaceToDB(viewModel);

            return Content("The organisation will be reviewed and if accepted, the info will be added to the catalogue within a few days :) ");
        }

    }
}
