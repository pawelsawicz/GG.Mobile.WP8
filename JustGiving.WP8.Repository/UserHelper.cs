using JustGiving.WP8.Repository.Models;
using JustGiving.WP8.Repository.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.WP8.Repository
{
    public static class UserHelper
    {
        public static IsolatedStorageSettings _insolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;

        public static Account BasicAuthenticator
        {
            get
            {
                return (Account)_insolatedStorageSettings["BasicAuthenticator"];
            }
            set
            {
                if (_insolatedStorageSettings.Contains("BasicAuthenticator"))
                {
                    _insolatedStorageSettings["BasicAuthenticator"] = value;
                }
                else
                {
                    _insolatedStorageSettings.Add("BasicAuthenticator", value);
                }

                _insolatedStorageSettings.Save();
            }
        }

        public static AccountVerefication User
        {
            get
            {
                return (AccountVerefication)_insolatedStorageSettings["userAccount"];
            }
            set
            {
                if (_insolatedStorageSettings.Contains("userAccount"))
                {
                    _insolatedStorageSettings["userAccount"] = value;
                }
                else
                {
                    _insolatedStorageSettings.Add("userAccount", value);
                }

                _insolatedStorageSettings.Save();
            }
        }
    }
}
