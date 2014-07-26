using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace JustGiving.WP8.Models
{
    public class RegistrationPropertyViewModel : PropertyChangedBase
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }
        private string _line;
        public string Line
        {
            get { return _line; }
            set
            {
                _line = value;
                NotifyOfPropertyChange(() => Line);
            }
        }
        private string _postCode;
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                NotifyOfPropertyChange(() => PostCode);
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }
    }
}
