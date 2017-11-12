using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_MIF2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseOpponentPage : ContentPage
    {
        public ChooseOpponentPage()
        {
            InitializeComponent();
            //BindingContext = new ChooseOpponentViewModel();
        }
    }
}