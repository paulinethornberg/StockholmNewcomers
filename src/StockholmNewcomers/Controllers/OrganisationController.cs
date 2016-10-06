﻿using System;
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
        public IActionResult AddOrganisation()
        {
            var tags = dataManager.GetTagsFromDB();
            AddOrganisationVM addOrgVM = new AddOrganisationVM();
            addOrgVM.Tags = tags;
            return View(addOrgVM);
        }
        [HttpPost]
        public IActionResult AddOrganisation(AddOrganisationVM viewModel)

        {
            if (!ModelState.IsValid)
                return View();

             // MÅSTE GÖRA EN CHECK SÅ ATT INFON INTE ÄR SQL INJECTION :) 
             dataManager.SaveOrganisationToDB(viewModel);

            return Content("The organisation will be reviewed and if accepted, the info will be added to the catalogue within a few days :) ");
        }

        public IActionResult GetResultByCategory(string checkbox1, bool checkResp = false)
        {
            //var result = dataManager.SortOrgByCat(categoryNum);

            return Content("hello");
        }

    }
}
