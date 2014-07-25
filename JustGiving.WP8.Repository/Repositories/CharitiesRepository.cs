using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace JustGiving.WP8.Repository.Repositories
{
    public class CharitiesRepository : RepositoryBase
    {
        private readonly XmlDeserializer _deserializer;

        public CharitiesRepository()
        {
            _deserializer = new XmlDeserializer();
        }

        public async Task<IEnumerable<CharitySearchResult>> GetSixRandomCharities()
        {
            IEnumerable<CharitySearchResult> responseModel;
            Request.Resource = "/charity/search";
            Request.AddParameter("pageSize", 6);
            Request.Method = Method.GET;
            Request.RequestFormat = DataFormat.Xml;

            var response = await Client.GetResponseAsync(Request);
            try
            {
                responseModel = _deserializer.Deserialize<List<CharitySearchResult>>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responseModel;
        }
    }

    public class CharitySearchResult
    {
        public string CharityId { get; set; }
        public string CountryCode { get; set; }
        public string Description { get; set; }
        public string LogoFileName { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
