﻿using Foosball_Lib.Models;
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
            Label_HomeTeam.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();
            Label_AwayTeam.Text = Constants.OponentName + " : " + Constants.AwayGoalCount.ToString();
            Label_HomeTeam.TextColor = Constants.MainTextColor;
            Label_AwayTeam.TextColor = Constants.MainTextColor;

            Btn_HomeGoal.Text = Constants.LocalUser.UserId + " scored!";
            Btn_AwayGoal.Text = Constants.OponentName + " scored!";
        }

        public void HomeGoalProcedure(object e, EventArgs s)
        {
            Constants.HomeGoalCount++;
            Label_HomeTeam.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();
            if (Constants.HomeGoalCount >= Constants.GoalLimit)
            {
                DisplayAlert("Win", "Player " + Constants.OponentName + " won the game!", "Ok");
                Constants.OponentName = "";
                Constants.HomeGoalCount = 0;
                Constants.AwayGoalCount = 0;
                Navigation.PushModalAsync(new PropertiesPage());
            }
        }

        public void AwayGoalProcedure(object e, EventArgs s)
        {
            Constants.AwayGoalCount++;
            Label_AwayTeam.Text = Constants.LocalUser.UserId + " : " + Constants.HomeGoalCount.ToString();

            if (Constants.AwayGoalCount >= Constants.GoalLimit)
            {
            DisplayAlert("Win", Constants.OponentName + " won the game!", "Ok");
            Constants.OponentName = "";
            Constants.HomeGoalCount = 0;
            Constants.AwayGoalCount = 0;
            Navigation.PushModalAsync(new PropertiesPage());
            }

        }
    }
}