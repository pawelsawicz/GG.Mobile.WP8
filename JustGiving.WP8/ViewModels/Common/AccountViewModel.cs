using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;
using JustGiving.WP8.Repository.Repositories;
using JustGiving.WP8.Repository.Models;
using JustGiving.WP8.Repository;
namespace JustGiving.WP8.ViewModels.Common
{
    public class AccountViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly AccountRepository _accountRepository;

        private BindableCollection<FundraisingPage> _userFundraisingPages;
        public BindableCollection<FundraisingPage> UserFundraisingPages
        {
            get
            {
                return _userFundraisingPages;
            }
            set
            {
                _userFundraisingPages = value;
                NotifyOfPropertyChange(() => UserFundraisingPages);
            }
        }

        private BindableCollection<Donation> _userDonations;
        public BindableCollection<Donation> UserDonations
        {
            get
            {
                return _userDonations;
            }
            set
            {
                _userDonations = value;
                NotifyOfPropertyChange(() => UserDonations);
            }
        }

        private AccountVerefication _accountInformation;
        public AccountVerefication AccountInformation
        {
            get
            {
                return _accountInformation;
            }
            set
            {
                _accountInformation = value;
                NotifyOfPropertyChange(() => AccountInformation);
            }
        }        

        public AccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountRepository = new AccountRepository();
            LoadPageContent();
        }

        private async void LoadPageContent()
        {
            UserFundraisingPages = new BindableCollection<FundraisingPage>();
            UserDonations = new BindableCollection<Donation>();
            UserFundraisingPages.AddRange(await _accountRepository.GetFundraisingPagesForUser(UserHelperIsolatedStorage.User.Email));
            UserDonations.AddRange(await _accountRepository.GetDonationsForUser());
            AccountInformation = UserHelperIsolatedStorage.User;
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
