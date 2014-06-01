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
        public int activePageCount { get; set; }
        public int completedPagesCount { get; set; }
        public decimal totalDonated { get; set; }
        public decimal totalDonatedGiftAid { get; set; }
        public decimal totalGiftAid { get; set; }
        public decimal totalRaised { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
