using Foosball_MIF2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_MIF2.Services
{
    public interface INavigator
    {
        Task PopAsync();

        Task PopToRootAsync();

        Task PushAsync<TViewModel>()
            where TViewModel : class, IViewModel;

        Task PushModalAsync<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}
