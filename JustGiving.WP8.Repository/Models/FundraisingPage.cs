using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JustGiving.WP8.Repository.Models
{
    public class FundraisingPage
    {
        public FundraisingPage()
        {
            //InMemoryPerson = new Person();
        }

        public int CompanyAppealId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public int DesignId { get; set; }
        public string Domain { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int GiftAidPlusSupplement { get; set; }
        public Person InMemoryPerson { get; set; }
        public double OfflineDonations { get; set; }
        public int PageId { get; set; }
        public string PageShortName { get; set; }
        public string PageStatus { get; set; }
        public string PageTitle { get; set; }
        public double RaisedAmount { get; set; }
        public double  TargetAmount { get; set; }
        public double TotalRaisedOnline { get; set; }
        public string SmsCode { get; set; }
        public int CharityId { get; set; }
    }
}
