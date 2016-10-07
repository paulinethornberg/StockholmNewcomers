using Microsoft.AspNetCore.Http;
using StockholmNewcomers.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StockholmNewcomers.Models.ViewModels
{
    public class AddOrganisationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Title { get; internal set; }
        public string Facebook { get; internal set; }

        //[FileExtensions(Extensions = ".jpeg, .png", ErrorMessage = "Please select a file with the right format.")]

        public ICollection<IFormFile> Files { get; set; }

        public List<Tags> Tags { get; set; }
    }
}
