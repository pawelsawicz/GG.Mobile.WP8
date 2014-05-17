using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
namespace JustGiving.WP8.ViewModels.Access
{
    public class RegistrationViewModel : PropertyChangedBase 
    {
        private readonly INavigationService _navigationService;

        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void NavigateToHelp()
        {

        }

        public void NavigateToLogin()
        {
            _navigationService.UriFor<LoginViewModel>().Navigate();
        }

        public void NavigateToFacebookLogin()
        {

        }

        public void NavigateToTermsAndConditions()
        {

        }
    }
}
