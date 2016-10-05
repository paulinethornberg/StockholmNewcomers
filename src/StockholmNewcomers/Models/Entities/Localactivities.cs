using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class Localactivities
    {
        public Localactivities()
        {
            LocalactivitiesTags = new HashSet<LocalactivitiesTags>();
        }

        public int Id { get; set; }
        public short? Type { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
        public int? Ord { get; set; }
        public short? Approve { get; set; }
        public DateTime? AddDate { get; set; }

        public virtual ICollection<LocalactivitiesTags> LocalactivitiesTags { get; set; }
    }
}
