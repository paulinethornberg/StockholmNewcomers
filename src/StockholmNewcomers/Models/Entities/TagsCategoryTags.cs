using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class TagsCategoryTags
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int TagsId { get; set; }

        public virtual Organizations Organization { get; set; }
        public virtual Tags Tags { get; set; }
    }
}
