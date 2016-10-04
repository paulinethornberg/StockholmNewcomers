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

        internal HomePageVM GetOrganisationsFromDB()
        {
            //OrganisationsVM OrganisationsToShow = new OrganisationsVM();

            var allTags = GetTagsFromDB();

            var allOrganizationTags = _context.OrganizationsTags.ToList();

            var organisations = _context.Organizations
                .Select(c => new OrganisationsVM {
                    Name = c.Name,
                    Logo = c.Logo,
                    Description = c.Description,
                    Type = c.Type,
                    Summary = c.Summary,
                    Id = c.Id,
                    Email = c.Email,
                    Info = c.Info ,
                    Website = c.Website,
                    Tags = GetTagsForThisOrganization(c.Id,allTags,allOrganizationTags),
                    })
                .ToArray();

            HomePageVM homePageInfo = new HomePageVM();
            homePageInfo.OrganisationArray = organisations;

            return homePageInfo;
        }

        internal List<Tags> GetTagsFromDB()
        {
            return _context.Tags.ToList();
        }

        private List<Tags> GetTagsForThisOrganization(int organizationId,List<Tags> allTags, List<OrganizationsTags> allOrganizationTags)
        {
            var tagIdList = allOrganizationTags
                 .Where(t => t.OrganizationId == organizationId)
                 .Select(c => c.TagsId)
                 .ToList();
          
            List < Tags > taggarna = new List<Tags>();
            foreach (int id in tagIdList) {
                taggarna.AddRange(allTags.Where(x => x.Id == id).ToList());
            }
            return taggarna;
            
            //var intTagId = Convert.ToInt32(tagId);

            //var tags = (from o in OrganizationsTags
            //    join t in Tags on o.TagsId equals t.Tags
            //    where 
            //return _context.Tags
            //    .Where(c => c.Id = intTagId)
            //    .SelectMany(p => new Tags { Title = p.Title, })
        }

        internal Organizations[] SortOrgByCat(string id)
        {
            int catNum;
            switch (id)
            {
                case "checkbox1":
                    catNum = 3;
                    break;
                case "checkbox2":
                    catNum = 2;
                    break;
                case "checkbox3":
                    catNum = 4;
                    break;
            }
            Organizations[] orgArray = new Organizations[2];
            return orgArray;
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
                Website = viewModel.Website, 
                Email = viewModel.Email,           
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
