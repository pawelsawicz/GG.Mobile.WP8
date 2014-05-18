using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using JustGiving.WP8.ViewModels.Team;

namespace JustGiving.WP8.ViewModels.Fundraising
{
    public class FundraisingViewModel : PropertyChangedBase 
    {
        private readonly INavigationService _navigateService;

        public FundraisingViewModel(INavigationService navigateService)
        {
            _navigateService = navigateService;
        }

        public void NavigateToTeam()
        {
            _navigateService.UriFor<TeamViewModel>().Navigate();
        }
    }
}
