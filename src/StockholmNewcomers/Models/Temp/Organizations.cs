using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Temp
{
    public partial class Organizations
    {
        public Organizations()
        {
            OrganizationsTags = new HashSet<OrganizationsTags>();
            TagsCategoryTags = new HashSet<TagsCategoryTags>();
        }

        public int Id { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
        public int? Ord { get; set; }
        public byte? Approve { get; set; }
        public DateTime? AddDate { get; set; }
        public string Facebook { get; set; }

        public virtual ICollection<OrganizationsTags> OrganizationsTags { get; set; }
        public virtual ICollection<TagsCategoryTags> TagsCategoryTags { get; set; }
    }
}
