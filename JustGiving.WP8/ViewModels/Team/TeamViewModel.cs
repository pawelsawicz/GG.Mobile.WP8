using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace JustGiving.WP8.ViewModels.Team
{
    public class TeamViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public TeamViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
