using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockholmNewcomers.Models
{
    public class Organisation
    {

        public int Id { get; set; }

        public string type { get; set; }
        public string Name { get; set; }

        public string Descr { get; set; }

        public string Email { get; set; }


        public string Website { get; set; }
        public string Facebook { get; set; }
        public string PhoneNumber { get; set; }



        public string ImageLink { get; set; }

        //public List<Category> Categories { get; set; }

        public DateTime Created { get; set; }
    }
}
