using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StockholmNewcomers.Models.Entities;
using StockholmNewcomers.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockholmNewcomers.Models
{
    public class DataManager
    {
        StockholmForNewcomersContext _context;
        UserManager<IdentityUser> _userManager;

        public DataManager(StockholmForNewcomersContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        internal OrganisationsVM[] GetOrganisationsFromDB()
        {
            //OrganisationsVM OrganisationsToShow = new OrganisationsVM();

            var organisations = _context.Organizations
                .Select(c => new OrganisationsVM {Name = c.Name, Logo = c.Logo, Description = c.Description, Type = c.Type, Summary = c.Summary, Id = c.Id, Email = c.Email, Info = c.Info , Website = c.Website})
                .ToArray();

            return organisations;
        }

        internal OrganisationsVM GetOrganisationFromId(int id)
        {

            var organisation = _context.Organizations
                 .Where(a => a.Id == id)
                 .Select(c => new OrganisationsVM { Name = c.Name, Logo = c.Logo, Description = c.Description, Type = c.Type, Summary = c.Summary, Email = c.Email, Info = c.Info, Website = c.Website })
                 .FirstOrDefault();

            return organisation;
        }

        internal async Task SaveOrganisationToDB(OrganisationsVM viewModel)
        {
            //make Organisations from ViewModel. 

            var organisation = new Organisations
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Logo = viewModel.Logo,
                Description = viewModel.Description,
                Summary = viewModel.Summary,
                Info = viewModel.Info,
                Website = viewModel.Website, 
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber               
            };

            _context.Organisations.Add(organisation);
            _context.SaveChanges();
            
        }

        internal MeetingPlacesVM[] GetMeetingPlacesFromDB()
        {

            var meetingPlaces = _context.Localactivities
                .Select(c => new MeetingPlacesVM {
                    Name = c.Title,
                    Description = c.Description,
                    Id = c.Id,
                    Email = c.Email,
                    Info = c.Info,
                    Summary = c.Summary,
                    Logo = c.Logo,
                    Website = c.Website
                    })
                .ToArray();

            return meetingPlaces;
        }
    }
}
