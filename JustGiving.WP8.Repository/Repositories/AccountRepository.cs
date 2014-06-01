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

}
