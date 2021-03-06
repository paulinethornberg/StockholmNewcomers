﻿using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class TagsCategory
    {
        public int Id { get; set; }
        public short? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? AddDate { get; set; }
        public string Lang { get; set; }
        public short? Approve { get; set; }
        public int? Ord { get; set; }
    }
}
