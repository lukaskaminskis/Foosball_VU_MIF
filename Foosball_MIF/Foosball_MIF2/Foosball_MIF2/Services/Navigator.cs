using Foosball_MIF2.Factory;
using Foosball_MIF2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foosball_MIF2.Services
{
    public class Navigator : INavigator
    {
        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewfactory;

        public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory)
        {
            _navigation = navigation;
            _viewfactory = viewFactory;
        }

        private INavigation Navigation
        {
            get
            {
                return _navigation.Value;
            }
        }

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>()
            where TViewModel : class, IViewModel
        {
            var view = _viewfactory.Resolve<TViewModel>();
            await Navigation.PushAsync(view);
        }

        public async Task PushModalAsync<TViewModel>()
            where TViewModel : class, IViewModel
        {
            var view = _viewfactory.Resolve<TViewModel>();
            await Navigation.PushModalAsync(view);
        }
    }
}
