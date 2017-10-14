using Foosball_Lib.Models;
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

            //Btn_HomeGoal.Text = Constants.LocalUser.UserId + " scored!";
            //Btn_AwayGoal.Text = Constants.OponentName + " scored!";
        }

        public void HomeGoalProcedure(object e, EventArgs s)
        {
            Constants.HomeGoalCount++;
            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();
            if (Constants.HomeGoalCount >= Constants.GoalLimit)
            {
                DisplayAlert(Labels.Win, Labels.Player + Constants.OponentName + Labels.WonGame, Labels.Ok);
                Constants.OponentName = "";
                Constants.HomeGoalCount = 0;
                Constants.AwayGoalCount = 0;
                Navigation.PushModalAsync(new PropertiesPage());
            }
        }

        public void AwayGoalProcedure(object e, EventArgs s)
        {
            Constants.AwayGoalCount++;
            Btn_AwayGoal.Text = Constants.OponentName + " : " + Constants.AwayGoalCount.ToString();

            if (Constants.AwayGoalCount >= Constants.GoalLimit)
            {
                DisplayAlert(Labels.Win, Constants.OponentName + Labels.WonGame, Labels.Ok);
                Constants.OponentName = "";
                Constants.HomeGoalCount = 0;
                Constants.AwayGoalCount = 0;
                Navigation.PushModalAsync(new PropertiesPage());
            }

        }
    }
}