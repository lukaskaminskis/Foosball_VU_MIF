using Foosball_MIF2.FileManagement;
using Foosball_MIF2.Models;
using Foosball_MIF2.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_MIF2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterOponentName : ContentPage
    {
        ObservableCollection<User> opponents = new ObservableCollection<User>();
        public EnterOponentName()
        {
            InitializeComponent();
            BindingContext = new ChooseOpponentViewModel();
            //Init();
        }

       /* public async void Init()
        {
            OpponentView.IsPullToRefreshEnabled = true;
            var users = new List<User>();
            BackEnd backEndOpponent = new BackEnd();
            users = await backEndOpponent.GetUsersList();

            OpponentView.ItemsSource = opponents;
            foreach (User user in users)
            {
                if (user.UserId != Constants.LocalUser.UserId)
                {
                    opponents.Add(user);
                }
            }
            //BackgroundColor = Constants.BackgroundColor;
            //Lbl_OponentName.TextColor = Constants.MainTextColor;
            //LogoIcon.HeightRequest = Constants.LoginIconHeight;
            //Entry_OponentName.Text = Constants.OponentName;
        } */

        //public async void SubmitProcedure(object e, EventArgs s)
        //{
        //    if (Validation.UsernamePatternMatch(Entry_OponentName.Text))
        //    {
        //        Constants.OponentName = Entry_OponentName.Text;
        //        await Navigation.PopModalAsync();
        //    }
        //    else
        //    {
        //        await DisplayAlert(Labels.Failed, Labels.OpNameNotMatch, Labels.Ok);
        //    }
        //}

        /*protected override bool OnBackButtonPressed()
        {
            return true;
        }*/

        void DoStuff(object e, EventArgs s)
        {
            DisplayAlert("Alert", "You pressed" + e.ToString(), "ok");
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + "more context action", "Ok");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + "more context action", "Ok");
        }
    }
}