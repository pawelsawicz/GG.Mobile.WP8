using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.Repository.Repositories;
using JustGiving.WP8.ViewModels.Access;
using JustGiving.WP8.ViewModels.Fundraising;
using System.Windows;
using System.IO.IsolatedStorage;
using System.ComponentModel;
using JustGiving.WP8.ViewModels.Common;

namespace JustGiving.WP8.ViewModels
{
    public class MainPageViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly CharitiesRepository _charitiesRepository;

        public BindableCollection<CharitySearchResult> Charities { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _charitiesRepository = new CharitiesRepository();
            Charities = new BindableCollection<CharitySearchResult>();
            LoadPageContent();
        }        

        public void TileTap()
        {
            _navigationService.UriFor<FundraisingViewModel>().Navigate();
        }

        public void BackKeyPressed(CancelEventArgs eventArgs)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("userAccount"))
            {
                eventArgs.Cancel = true;
            }
            else
            {
                MessageBox.Show("Logout");
                _navigationService.UriFor<LoginViewModel>().Navigate();
            }            
        }

        public void NavigateToAccount()
        {
            _navigationService.UriFor<AccountViewModel>().Navigate();
        }

        private async void LoadPageContent()
        {
            Charities.AddRange(await _charitiesRepository.GetSixRandomCharities());
        }
    }
}
