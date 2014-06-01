using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository.Models
{
    public class Address
    {
        public string Country { get; set; }
        public string CountyOrState { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostCodeOrZipCode { get; set; }
        public string TownOrCity { get; set; }
    }
}
