using Foosball_Lib.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        private int awayGoalCount = 0;
        private int homeGoalCount = 0;

        public MatchPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + homeGoalCount.ToString();
            Btn_AwayGoal.Text = Constants.opponent.UserId + " : " + awayGoalCount.ToString();
            Btn_HomeGoal.TextColor = Constants.MainTextColor;
            Btn_AwayGoal.TextColor = Constants.MainTextColor;
        }

        public async void HomeGoalProcedure(object e, EventArgs s)
        {
            homeGoalCount++;
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + homeGoalCount.ToString();
            if (homeGoalCount >= Constants.GoalLimit)
            {
                homeGoalCount = 0;
                awayGoalCount = 0;
                await DisplayAlert(Labels.Win, Labels.Player + Constants.LocalUser.UserId + Labels.WonGame, Labels.Ok);
                await Navigation.PopModalAsync(false);
            }
        }

        public async void AwayGoalProcedure(object e, EventArgs s)
        {
            awayGoalCount++;
            Btn_AwayGoal.Text = Constants.opponent.UserId + " : " + awayGoalCount.ToString();

            if (awayGoalCount >= Constants.GoalLimit)
            {
                homeGoalCount = 0;
                awayGoalCount = 0;
                await  DisplayAlert(Labels.Win, Labels.Player + Constants.opponent.UserId + Labels.WonGame, Labels.Ok);
                await Navigation.PopModalAsync(false);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}