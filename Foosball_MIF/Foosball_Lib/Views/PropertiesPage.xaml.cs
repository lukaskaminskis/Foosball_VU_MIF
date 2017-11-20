using Foosball_Lib.FileManagement;
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

        async void Init()
        {
            Constants.userList      = await BackEnd.GetUserListAsync();
            Lbl_Hello.TextColor     = Constants.MainTextColor;
            Lbl_User.TextColor      = Constants.MainTextColor;
            Lbl_User.Text           = "Welcome " + Constants.LocalUser.UserId;
            LogoIcon.HeightRequest  = Constants.LoginIconHeight;
        }

        public async void NewOponentProcedure(object e, EventArgs s)
        {
            await Navigation.PushModalAsync(new OpponentListViewPage(), false);
        }

        public async void SetGoalLimitProcedure(object e, EventArgs s)
        {
            await Navigation.PushModalAsync(new GoalLimit(), false);
        }

        async void Logout(object sender, EventArgs e)
        {
            Constants.LocalUser = null;
            Constants.GoalLimit = 0;
            await Navigation.PopModalAsync(false);
        }

        async void StartMatchProcedure(object sender, EventArgs e)
        {
            if (Constants.opponent == null)
            {
                await DisplayAlert(Labels.NoOp, Labels.OpNotChosen, Labels.Ok);
            }
            else
            {
                await Navigation.PushModalAsync(new MatchPage(), false);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}