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

        public string UserName { get; set; }
        public string Password { get; set; }

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
            
        }

        public void NavigateToHelp()
        {

        }
    }
}
