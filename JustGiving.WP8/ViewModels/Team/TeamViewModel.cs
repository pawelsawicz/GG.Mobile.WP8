using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.ViewModels.Fundraising;

namespace JustGiving.WP8.ViewModels.Team
{
    public class TeamViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public TeamViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void NavigateToFundraisingPage()
        {
            _navigationService.UriFor<FundraisingViewModel>().Navigate();
        }

        public void NavigateToDonate()
        {

        }

        public void NavigateToHelp()
        {

        }
    }
}
