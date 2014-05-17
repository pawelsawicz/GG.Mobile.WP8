using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustGiving.WP8.ViewModels;
using JustGiving.WP8.ViewModels.Access;
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
