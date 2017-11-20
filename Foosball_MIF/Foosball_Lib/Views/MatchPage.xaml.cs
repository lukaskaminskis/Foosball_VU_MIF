using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public event Action<User, User> MatchPlayedEvent;
        private int awayGoalCount = 0;
        private int homeGoalCount = 0;

        public MatchPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            MatchPlayedEvent += new Action<User, User>(MatchPlayedEventHandler);
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + homeGoalCount.ToString();
            Btn_AwayGoal.Text = Constants.opponent.UserId + " : " + awayGoalCount.ToString();
            Btn_HomeGoal.TextColor = Constants.MainTextColor;
            Btn_AwayGoal.TextColor = Constants.MainTextColor;

            Btn_HomeGoal.Clicked += async delegate (object e, EventArgs s)
            {
                homeGoalCount++;
                Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + homeGoalCount.ToString();
                if (homeGoalCount >= Constants.GoalLimit)
                {
                    homeGoalCount = 0;
                    awayGoalCount = 0;
                    MatchPlayedEvent(Constants.LocalUser, Constants.opponent);
                    await DisplayAlert(Labels.Win, Labels.Player + Constants.LocalUser.UserId + Labels.WonGame, Labels.Ok);
                    await Navigation.PopModalAsync(false);
                }
            };

            Btn_AwayGoal.Clicked += async delegate (object e, EventArgs s)
            {
                awayGoalCount++;
                Btn_AwayGoal.Text = Constants.opponent.UserId + " : " + awayGoalCount.ToString();

                if (awayGoalCount >= Constants.GoalLimit)
                {
                    homeGoalCount = 0;
                    awayGoalCount = 0;
                    MatchPlayedEvent(Constants.opponent, Constants.LocalUser);
                    await DisplayAlert(Labels.Win, Labels.Player + Constants.opponent.UserId + Labels.WonGame, Labels.Ok);
                    await Navigation.PopModalAsync(false);
                }
            };
        }

        /*public async void HomeGoalProcedure(object e, EventArgs s)
        {
            homeGoalCount++;
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + homeGoalCount.ToString();
            if (homeGoalCount >= Constants.GoalLimit)
            {
                homeGoalCount = 0;
                awayGoalCount = 0;
                MatchPlayedEvent(Constants.LocalUser, Constants.opponent);
                await DisplayAlert(Labels.Win, Labels.Player + Constants.LocalUser.UserId + Labels.WonGame, Labels.Ok);
                await Navigation.PopModalAsync(false);
            }
        } */

        /*public async void AwayGoalProcedure(object e, EventArgs s)
        {
            awayGoalCount++;
            Btn_AwayGoal.Text = Constants.opponent.UserId + " : " + awayGoalCount.ToString();

            if (awayGoalCount >= Constants.GoalLimit)
            {
                homeGoalCount = 0;
                awayGoalCount = 0;
                MatchPlayedEvent(Constants.opponent, Constants.LocalUser);
                await  DisplayAlert(Labels.Win, Labels.Player + Constants.opponent.UserId + Labels.WonGame, Labels.Ok);
                await Navigation.PopModalAsync(false);
            }
        }*/

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void MatchPlayedEventHandler(User win, User lost)
        {
            foreach (User user in Constants.userList)
            {
                if (user.UserId == win.UserId)
                {
                    user.MatchWon();
                }
                else if (user.UserId == lost.UserId)
                {
                    user.MatchLost();
                }
            }
            BackEnd.UpdateUserList();
        }
    }
}