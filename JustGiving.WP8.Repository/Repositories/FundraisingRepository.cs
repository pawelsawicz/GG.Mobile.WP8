using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository.Repositories
{
    public class FundraisingRepository : RepositoryBase
    {
        private readonly XmlDeserializer _deserialiser;

        public FundraisingRepository()
        {
            _deserialiser = new XmlDeserializer();
        }

        public void GetFundraisingPageDetails()
        {

        }

        public class FundraisingPage
        {
            public bool ActivityCharityCreated { get; set; }
            public string ActivityId { get; set; }
            public int ActivityType { get; set; }
            public Branding Branding { get; set; }
            public Charity Charity { get; set; }
            public string CompanyAppealId { get; set; }
            public string CurrencySymbol { get; set; }
            public string Domain { get; set; }
            public DateTime EventDate { get; set; }
            public int EventId { get; set; }
            public string EventName { get; set; }
            public double FundraisingTarget { get; set; }
            public string Owner { get; set; }
            public string PageId { get; set; }
            public string PageSummary { get; set; }
            public string PageSummaryWhat { get; set; }
            public string PageSummaryWhy { get; set; }
            public string RememberedPersonSummary { get; set; }
            public bool ShowEventDate { get; set; }
            public bool ShowExpiryDate { get; set; }
            public string SmsCode { get; set; }
            public string Status { get; set; }
            public string Story { get; set; }
            public string Title { get; set; }
            public double TotalEstimatedGiftAid { get; set; }
            public double TotalRaisedOffline { get; set; }
            public double TotalRaisedOnline { get; set; }
            public int TotalRaisedPercentageOfFundraisingTarget { get; set; }
            public double TotalRaisedSms { get; set; }
        }

        public class Branding
        {
            public string ButtonColour { get; set; }
            public string ButtonTextColour { get; set; }
            public string HeaderTextColour { get; set; }
            public string ThermometerBackgroundColour { get; set; }
            public string ThermometerFillColour { get; set; }
            public string ThermometerTextColour { get; set; }
        }

        public class Charity
        {
            public string Description { get; set; }
            public int Id { get; set; }
            public string LogoUrl { get; set; }
            public string Name { get; set; }
            public string ProfilePageUrl { get; set; }
            public string RegistrationNumber { get; set; }
        }
    }
}
