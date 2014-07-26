using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository.Models
{
    public class AccountRegistration
    {
        public AccountRegistration()
        {
            Address = new Address();
            AcceptTermsAndConditions = true;
        }

        public bool AcceptTermsAndConditions { get; set; }
        public Address Address { get; set; }
        public int CauseId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
       
    }
}
