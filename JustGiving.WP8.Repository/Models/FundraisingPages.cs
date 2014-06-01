using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JustGiving.WP8.Repository.Models
{    
    
    public class FundraisingPages
    {
        public FundraisingPages()
        {
            FundraisingPage = new List<FundraisingPage>();
        }       
        
        public List<FundraisingPage> FundraisingPage { get; set; }
    }
}
