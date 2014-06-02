using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace JustGiving.WP8.Repository.Repositories
{
    public class CountriesRepository : RepositoryBase
    {
        private readonly XmlDeserializer _deserializer;

        public CountriesRepository()
        {
            _deserializer = new XmlDeserializer();
        }

        public async Task<List<Country>> GetListOfCountries()
        {
            var responseModel = new List<Country>();
            Request.Resource = "/countries";
            Request.Method = Method.GET;
            var response = await Client.GetResponseAsync(Request);
            responseModel = _deserializer.Deserialize<List<Country>>(response);
            return responseModel;
        }

        public class Country
        {
            public string CountryCode { get; set; }
            public string Name { get; set; }
        }
    }
}
