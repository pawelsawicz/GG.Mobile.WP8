using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace JustGiving.WP8.Repository.Repositories
{
    public class AccountRepository
    {
        public async void AuthenticateAccount(string userName, string password)
        {
            var client = new RestClient("https://api-sandbox.justgiving.com/v1");
            client.Authenticator = new HttpBasicAuthenticator("", "");
            var request = new RestRequest("/account", Method.GET);
            request.AddHeader("x-api-key", "0f938d22");
            var response = await client.GetContentAsync(request);   
                     
        }        
    }

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
