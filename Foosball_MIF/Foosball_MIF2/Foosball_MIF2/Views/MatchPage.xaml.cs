using Foosball_Lib.Models;
using Foosball_MIF2.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public MatchPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();
            Btn_AwayGoal.Text = Constants.OponentName + " : " + Constants.AwayGoalCount.ToString();
            Btn_HomeGoal.TextColor = Constants.MainTextColor;
            Btn_AwayGoal.TextColor = Constants.MainTextColor;
        }

        public async void HomeGoalProcedure(object e, EventArgs s)
        {
            Constants.HomeGoalCount++;
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();
            if (Constants.HomeGoalCount >= Constants.GoalLimit)
            {
                await DisplayAlert(Labels.Win, Labels.Player + Constants.LocalUser.UserId + Labels.WonGame, Labels.Ok);
                Constants.OponentName = "";
                Constants.HomeGoalCount = 0;
                Constants.AwayGoalCount = 0;
                await Navigation.PopModalAsync();
            }
        }

        public async void AwayGoalProcedure(object e, EventArgs s)
        {
            Constants.AwayGoalCount++;
            Btn_AwayGoal.Text = Constants.OponentName + " : " + Constants.AwayGoalCount.ToString();

            if (Constants.AwayGoalCount >= Constants.GoalLimit)
            {
               await  DisplayAlert(Labels.Win, Labels.Player + Constants.OponentName + Labels.WonGame, Labels.Ok);
                Constants.OponentName = "";
                Constants.HomeGoalCount = 0;
                Constants.AwayGoalCount = 0;
                await Navigation.PopModalAsync();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}