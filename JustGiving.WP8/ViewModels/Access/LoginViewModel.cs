using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace JustGiving.WP8.ViewModels.Access
{
    public class LoginViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void TryLogin()
        {
            _navigationService.UriFor<MainPageViewModel>().Navigate();
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
