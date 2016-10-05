using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Temp
{
    public partial class Organisations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public byte[] DateAdded { get; set; }
        public string PhoneNumber { get; set; }
    }
}
