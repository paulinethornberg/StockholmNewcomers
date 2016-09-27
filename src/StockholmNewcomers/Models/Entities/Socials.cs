using System;
using System.Collections.Generic;

namespace StockholmNewcomers.Models.Entities
{
    public partial class Socials
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public int? ParentId { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
        public string Vimo { get; set; }
        public short? Approve { get; set; }
        public int? Ord { get; set; }
    }
}
