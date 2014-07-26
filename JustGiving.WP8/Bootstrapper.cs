using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustGiving.WP8.Repository.Repositories;
using JustGiving.WP8.ViewModels;
using JustGiving.WP8.ViewModels.Access;
using JustGiving.WP8.ViewModels.Fundraising;
using JustGiving.WP8.ViewModels.Team;
using System.Windows.Controls;
using Caliburn.Micro.BindableAppBar;
using JustGiving.WP8.ViewModels.Common;
namespace JustGiving.WP8
{
    public class Bootstrapper : PhoneBootstrapper
    {
        PhoneContainer _phoneContainer;

        protected override void Configure()
        {
            _phoneContainer = new PhoneContainer();
            _phoneContainer.RegisterPhoneServices(RootFrame);
            _phoneContainer.PerRequest<MainPageViewModel>();
            _phoneContainer.PerRequest<LoginViewModel>();
            _phoneContainer.PerRequest<RegistrationViewModel>();
            _phoneContainer.PerRequest<FundraisingViewModel>();
            _phoneContainer.PerRequest<TeamViewModel>();
            _phoneContainer.PerRequest<AccountViewModel>();

            ConventionManager.AddElementConvention<BindableAppBarMenuItem>(Control.IsEnabledProperty, "DataContext", "Click");
            ConventionManager.AddElementConvention<BindableAppBarButton>(Control.IsEnabledProperty, "DataContext", "Click");
        }

        protected override object GetInstance(Type service, string key)
        {
            return _phoneContainer.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _phoneContainer.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _phoneContainer.BuildUp(instance);
        }
    }
}
