using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;

namespace JustGiving.WP8.ViewModels.Common
{
    public class AccountViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public AccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
