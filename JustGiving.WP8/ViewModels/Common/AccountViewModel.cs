using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;
using JustGiving.WP8.Repository.Repositories;
using JustGiving.WP8.Repository.Models;

namespace JustGiving.WP8.ViewModels.Common
{
    public class AccountViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly AccountRepository _accountRepository;

        public List<FundraisingPage> UserFundraisingPages { get; set; }
        public List<Donation> UserDonations { get; set; }

        public AccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountRepository = new AccountRepository();
            LoadPageContent();
        }

        private async void LoadPageContent()
        {
            UserFundraisingPages = await _accountRepository.GetFundraisingPagesForUser("info@helbards.com");
            UserDonations = await _accountRepository.GetDonationsForUser();
        }

        public void NavigateToCreateNewPage()
        {
            MessageBox.Show("not implemented yet");
        }

        public void NavigateToCreateNewTeam()
        {
            MessageBox.Show("not implemented yet");
        }
    }
}
