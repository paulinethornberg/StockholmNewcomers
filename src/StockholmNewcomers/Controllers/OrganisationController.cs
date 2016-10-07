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
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class OrganisationController : Controller
    {
        // GET: /<controller>/
        DataManager dataManager;
        private IHostingEnvironment _environment;

        public OrganisationController(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager, IHostingEnvironment environment)
        {
            dataManager = new DataManager(context, userManager);
            _environment = environment;

        }
        public IActionResult Index(int id)
        {
            //hämta från databasen
            var organisation = dataManager.GetOrganisationFromId(id);
            
            return View(organisation);
        }
        public IActionResult AddOrganisation()
        {
            var tags = dataManager.GetTagsFromDB();
            AddOrganisationVM addOrgVM = new AddOrganisationVM();
            addOrgVM.Tags = tags;
            return View(addOrgVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrganisation(AddOrganisationVM viewModel)
        {
            //check if viewModel is valid && check HoneyBucket for bots & avoid spam
            if (!ModelState.IsValid || viewModel.HoneyBucket != null)
                return View(viewModel);

            var images = Path.Combine(_environment.WebRootPath, "images/Bilder");
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
           
            // MÅSTE GÖRA EN CHECK SÅ ATT INFON INTE ÄR SQL INJECTION :) 
            dataManager.SaveOrganisationToDB(viewModel);

            return RedirectToAction("AddOrganisation");
        }

        public IActionResult GetResultByCategory(string checkbox1, bool checkResp = false)
        {
            //var result = dataManager.SortOrgByCat(categoryNum);

            return Content("hello");
        }

    }
}
