using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.Repository.Repositories;
using System.Windows;

namespace JustGiving.WP8.ViewModels.Access
{
    public class LoginViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly AccountRepository _accountRepository;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanTryLogin);
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
                NotifyOfPropertyChange(() => CanTryLogin);
            }
        }
        public bool CanTryLogin
        {
            get
            {
                if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(UserName))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountRepository = new AccountRepository();
        }

        public async void TryLogin()
        {            
            if ( await _accountRepository.AuthenticateAccount(UserName, Password))
            {
                _navigationService.UriFor<MainPageViewModel>().Navigate();
            }
            else
            {
                MessageBox.Show("Invalid creditials");
            }
        }

        public void NavigateToRegistration()
        {
            _navigationService.UriFor<RegistrationViewModel>().Navigate();
        }

        public void NavigateToFacebookLogin()
        {
            MessageBox.Show("Not implemented yet!");
        }

        public void NavigateToHelp()
        {
            MessageBox.Show("Not implemented yet!");
        }
    }
}
