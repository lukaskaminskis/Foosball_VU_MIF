using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;

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

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Hello.TextColor = Constants.MainTextColor;
            Lbl_User.TextColor = Constants.MainTextColor;
            Lbl_User.Text = "Welcome " + Constants.LocalUser.UserId;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;
        }

        public async void NewOponentProcedure(object e, EventArgs s)
        {
            await Navigation.PushModalAsync(new OpponentListViewPage());
        }

        public async void SetGoalLimitProcedure(object e, EventArgs s)
        {
            await Navigation.PushModalAsync(new GoalLimit());
        }

        public async void StartMatchProcedure(object e, EventArgs s)
        {
            if (!Validation.IsOpponentAssigned())
            {
                await DisplayAlert(Labels.NoOp, Labels.OpNotChosen, Labels.Ok);
            }
            else if(!Validation.IsGoalLimitAssigned())
            {
                await DisplayAlert(Labels.NoLimit, Labels.GoalLimit, Labels.Ok);
            }
            else
            {
                await Navigation.PushModalAsync(new MatchPage());
            }
        }

        public async void Back()
        {
            Constants.OponentName = "";
            Constants.LocalUser = null;
            Constants.GoalLimit = 0;
            Constants.OponentName = "";
            Constants.HomeGoalCount = 0;
            Constants.AwayGoalCount = 0;
            await Navigation.PopModalAsync();
        }
    }
}