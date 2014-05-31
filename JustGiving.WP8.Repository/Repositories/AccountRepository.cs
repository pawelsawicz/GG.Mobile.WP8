using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
namespace JustGiving.WP8.Repository.Repositories
{
    public class AccountRepository : RepositoryBase
    {
        public async Task<bool> AuthenticateAccount(string userName, string password)
        {           
            Client.Authenticator = new HttpBasicAuthenticator(userName, password);
            Request.Resource = "/account";
            Request.Method = Method.GET;
            Request.RequestFormat = DataFormat.Xml;
            var response = await Client.GetResponseAsync(Request);            
            XmlDeserializer deserializer = new XmlDeserializer();
            var model = deserializer.Deserialize<AccountVerefication>(response);

            if (model != null)
            {
                AddAccountToSession(model);
                return true;
            }
            else
            {
                return false;
            }

        }

        private void AddAccountToSession(AccountVerefication model)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("userAccount"))
            {
                settings.Add("userAccount", model);
            }
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
