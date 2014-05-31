using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository.Repositories
{
    public class RepositoryBase
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public RepositoryBase()
        {
            Client = new RestClient("https://api-sandbox.justgiving.com/v1");
            Request = new RestRequest();
            SetRequestBasicConfiguration();
        }

        private void SetRequestBasicConfiguration()
        {
            Request.AddHeader("x-api-key", "0f938d22");
            Request.RequestFormat = DataFormat.Xml;
        }
    }
}
