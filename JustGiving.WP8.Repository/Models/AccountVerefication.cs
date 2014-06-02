using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository.Models
{
    public class AccountVerefication
    {
        public string Email { get; set; }
        public int ActivePageCount { get; set; }
        public int CompletedPagesCount { get; set; }
        public decimal TotalDonated { get; set; }
        public decimal TotalDonatedGiftAid { get; set; }
        public decimal TotalGiftAid { get; set; }
        public decimal TotalRaised { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
