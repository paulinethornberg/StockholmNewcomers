using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class LocalactivitiesTags
    {
        public int Id { get; set; }
        public int LocalactivityId { get; set; }
        public int TagsId { get; set; }

        public virtual Localactivities Localactivity { get; set; }
        public virtual Tags Tags { get; set; }
    }
}
