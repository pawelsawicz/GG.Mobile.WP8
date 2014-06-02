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
                SetAccountToIsolatedStorage(responseModel);
                SetBasicAuthenticatorToIsolatedStorage(userName, password);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetAccountToIsolatedStorage(AccountVerefication model)
        {
            UserHelperIsolatedStorage.User = model;            
        }

        private void SetBasicAuthenticatorToIsolatedStorage(string userName, string password)
        {
            try
            {
                UserHelperIsolatedStorage.BasicAuthenticator = new Account() { UserName = userName, Password = password };
            }
            catch (Exception ex)
            {
                throw ex;
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

        public async Task<List<Donation>> GetDonationsForUser()
        {
            Client.Authenticator = new HttpBasicAuthenticator(UserHelperIsolatedStorage.BasicAuthenticator.UserName, UserHelperIsolatedStorage.BasicAuthenticator.Password);
            var responseModel = new List<Donation>();
            Request.Resource = "/account/donations";
            Request.Method = Method.GET;
            Request.RequestFormat = DataFormat.Xml;
            var response = await Client.GetResponseAsync(Request);
            try
            {
                responseModel = _deserializer.Deserialize<List<Donation>>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseModel;
        }

    }

    public class Donation
    {
        public string Amount { get; set; }
        public string currencyCode { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationRef { get; set; }
        public string DonorDisplayName { get; set; }
        public string DonorLocalAmount { get; set; }
        public string DonorLocalCurrencyCode { get; set; }
        public double DstimatedTaxReclaim { get; set; }
        public int Id { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string ThirdPartyReference { get; set; }
        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string PaymentType { get; set; }

    }

    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
