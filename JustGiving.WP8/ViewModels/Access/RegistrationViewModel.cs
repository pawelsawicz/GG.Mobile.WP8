using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.Models;
using JustGiving.WP8.Repository.Repositories;
using System.Windows;
using JustGiving.WP8.Repository.Models;

namespace JustGiving.WP8.ViewModels.Access
{
    public class RegistrationViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly AccountRepository _accountRepository;
        private readonly CountriesRepository _countryRepository;

        private RegistrationPropertyViewModel _registrationPropertyViewModel;
        public RegistrationPropertyViewModel RegistrationPropertyViewModel
        {
            get { return _registrationPropertyViewModel; }
            set
            {
                _registrationPropertyViewModel = value;
                NotifyOfPropertyChange(() => RegistrationPropertyViewModel);
            }
        }
        

        public List<JustGiving.WP8.Repository.Repositories.CountriesRepository.Country> Countries { get; set; }

        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountRepository = new AccountRepository();
            _countryRepository = new Repository.Repositories.CountriesRepository();
            _registrationPropertyViewModel = new RegistrationPropertyViewModel();
            LoadPageContent();
        }

        public async void TrySignUp()
        {

            var result = await _accountRepository.RegisterAccount(mappedAccountRegistration());
            if (result != null)
            {
                var resultMessage = string.Format("{0} has been created", result.Email);
                MessageBox.Show(resultMessage);
                _navigationService.UriFor<LoginViewModel>().Navigate();
            }
            else
            {
                MessageBox.Show("Something went wrong please try again!");
            }
        }

        public void NavigateToHelp()
        {
            MessageBox.Show("Not implemented yet");
        }

        public void NavigateToLogin()
        {
            _navigationService.UriFor<LoginViewModel>().Navigate();
        }

        public void NavigateToTermsAndConditions()
        {
            MessageBox.Show("Not implemented yet");
        }

        private async void LoadPageContent()
        {
            Countries = await _countryRepository.GetListOfCountries();
        }

        private AccountRegistration mappedAccountRegistration()
        {
            var mappedObject = new AccountRegistration()
            {
                Email = _registrationPropertyViewModel.Email,
                Password = _registrationPropertyViewModel.Password,
                FirstName = _registrationPropertyViewModel.FirstName,
                LastName = _registrationPropertyViewModel.LastName,
                Address = new Address()
                {
                    Country = _registrationPropertyViewModel.Country,
                    Line1 = _registrationPropertyViewModel.Line,
                    PostCodeOrZipCode = _registrationPropertyViewModel.PostCode,
                    TownOrCity = _registrationPropertyViewModel.City
                },
                Title = _registrationPropertyViewModel.Title
            };

            return mappedObject;
        }
    }
}
