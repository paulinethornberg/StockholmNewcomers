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
 
        [HttpPost]
        public IActionResult AddMeetingPlace(MeetingPlacesVM viewModel)
        {
            return View();
        }

        public IActionResult AddMeetingPlace()
        {
            var tags = dataManager.GetTagsFromDB();
            AddOrganisationVM addVM = new AddOrganisationVM();
            addVM.Tags = tags;
            return View(addVM);
        }

    }
}
