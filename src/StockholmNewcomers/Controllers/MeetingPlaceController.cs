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
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class MeetingPlaceController : Controller
    {
        // GET: /<controller>/
        DataManager dataManager;
        private IHostingEnvironment _environment;

        public MeetingPlaceController(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager, IHostingEnvironment environment)
        {
            dataManager = new DataManager(context, userManager);
            _environment = environment;

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
        public async Task<IActionResult> AddMeetingPlace(AddMeetingPlaceVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var images = Path.Combine(_environment.WebRootPath, "images/Bilder/Activities");
            foreach (var file in viewModel.Files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(images, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        viewModel.Logo = file.FileName;
                    }
                }
            }
            dataManager.SaveMeetingPlaceToDB(viewModel);

            return View();
        }

    }
}
