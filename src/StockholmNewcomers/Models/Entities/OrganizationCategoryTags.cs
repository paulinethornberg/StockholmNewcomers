using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class OrganizationCategoryTags
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int TagsCategoryId { get; set; }

        public virtual Organizations Organization { get; set; }
        public virtual TagsCategory TagsCategory { get; set; }
    }
}
