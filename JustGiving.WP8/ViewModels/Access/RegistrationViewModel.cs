using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.Repository.Repositories;
using System.Windows;
using JustGiving.WP8.Repository.Models;

namespace JustGiving.WP8.ViewModels.Access
{
    public class RegistrationViewModel : PropertyChangedBase 
    {
        private readonly INavigationService _navigationService;
        private readonly AccountRepository _accountRepository;
        public AccountRegistration AccountRegistrationModel { get; set; }
        

        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountRepository = new AccountRepository();
            AccountRegistrationModel = new AccountRegistration();
            AccountRegistrationModel.AcceptTermsAndConditions = true;
        }

        public async void TrySignUp()
        {
            var result = await _accountRepository.RegisterAccount(AccountRegistrationModel);
            if (result != null)
            {
                var resultMessage = string.Format("{0} has been created", result.Email);
                MessageBox.Show(resultMessage);
                _navigationService.UriFor<LoginViewModel>().Navigate();
            }
            else
            {
                MessageBox.Show("Something goes wrong please try again!");
            }
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
