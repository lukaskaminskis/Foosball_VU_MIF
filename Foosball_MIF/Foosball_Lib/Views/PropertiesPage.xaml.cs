using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertiesPage : ContentPage
    {
        public PropertiesPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Hello.TextColor = Constants.MainTextColor;
            Lbl_User.TextColor = Constants.MainTextColor;
            Lbl_User.Text = "Welcome " + Constants.LocalUser.UserId;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;
        }

        public void NewOponentProcedure(object e, EventArgs s)
        {
            Navigation.PushModalAsync(new EnterOponentName());
        }

        public void SetGoalLimitProcedure(object e, EventArgs s)
        {
            Navigation.PushModalAsync(new GoalLimit());
        }

        async public void StartMatchProcedure(object e, EventArgs s)
        {
            if (!Validation.IsOpponentAssigned())
            {
                DisplayAlert("No opponent", "You haven't choosen your opponent", "Ok");
            }
            else if(!Validation.IsGoalLimitAssigned())
            {
                DisplayAlert("No Limit", "Goal Limit has not been assigned", "Ok");
            }
            else
            {
                await Navigation.PushModalAsync(new MatchPage());
            }
        }
    }
}