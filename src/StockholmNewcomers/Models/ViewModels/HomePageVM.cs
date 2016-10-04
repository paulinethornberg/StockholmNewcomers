using StockholmNewcomers.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockholmNewcomers.Models.ViewModels
{
    public class HomePageVM
    {
        public bool CheckBoxLanguage { get; set; }
        public bool CheckBoxCommunity { get; set; }
        public bool 
            Info { get; set; }

        public OrganisationsVM[] OrganisationArray { get; set; }
    }
}
