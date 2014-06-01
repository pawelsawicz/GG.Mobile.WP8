using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using JustGiving.WP8.Repository.Models;
namespace JustGiving.WP8.Repository.Repositories
{
    public class AccountRepository : RepositoryBase
    {
        private readonly XmlDeserializer _deserializer;

        public AccountRepository()
        {
            _deserializer = new XmlDeserializer();
        }

        public async Task<bool> AuthenticateAccount(string userName, string password)
        {
            Client.Authenticator = new HttpBasicAuthenticator(userName, password);
            Request.Resource = "/account";
            Request.Method = Method.GET;
            Request.RequestFormat = DataFormat.Xml;
            var response = await Client.GetResponseAsync(Request);
            var responseModel = _deserializer.Deserialize<AccountVerefication>(response);

            if (responseModel != null)
            {
                AddAccountToSession(responseModel);
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

        public async Task<AccountRegistrationResponse> RegisterAccount(AccountRegistration model)
        {
            Request.Resource = "/account";
            Request.Method = Method.PUT;
            Request.RequestFormat = DataFormat.Xml;
            Request.AddBody(model);
            var response = await Client.GetResponseAsync(Request);

            var responseModel = _deserializer.Deserialize<AccountRegistrationResponse>(response);

            if (responseModel != null)
            {
                return responseModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<FundraisingPage>> GetFundraisingPagesForUser(string email)
        {
            Request.Resource = "/account/{email}/pages";
            Request.AddUrlSegment("email", email);
            Request.Method = Method.GET;
            Request.RequestFormat = DataFormat.Xml;
            Request.RootElement = "fundraisingPages";
            var responseModel = new List<FundraisingPage>();
            var response = await Client.GetResponseAsync(Request);
            try
            {
                responseModel = _deserializer.Deserialize<List<FundraisingPage>>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseModel;
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

    public class AccountRegistration
    {
        public AccountRegistration()
        {
            Address = new Address();
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

    public class AccountRegistrationResponse
    {
        public string Country { get; set; }
        public string Email { get; set; }
    }

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
