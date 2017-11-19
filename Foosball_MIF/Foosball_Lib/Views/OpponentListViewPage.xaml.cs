using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpponentListViewPage : ContentPage
    {
        ObservableCollection<User> opponentList = new ObservableCollection<User>();
        User selectedUser;

        public OpponentListViewPage()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            foreach (User user in Constants.userList)
            {
                if (user.UserId != Constants.LocalUser.UserId)
                {
                    opponentList.Add(user);
                }
            }
            MyListView.ItemsSource = opponentList;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedUser = e.Item as User;
            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        void ChooseOpponent(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                Constants.opponent = selectedUser;
                Navigation.PopModalAsync(false);
            }
            else
            {
                DisplayAlert("Ok", "Player not selected", "Ok");
            }
        }

        async void DisplayPlayerInfo(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                await DisplayAlert(Labels.Failed, "Opponent has not been selected!", Labels.Ok);
            }
            else
            {
                await DisplayAlert(Labels.Info, $"Username : {selectedUser.UserId}" +
                    $"\nPassword: {selectedUser.GetPassword()}\nEmail: {selectedUser.Email}" +
                    $"\nWon :{selectedUser.Wins}\nLost :{selectedUser.Loses}", Labels.Ok);
            }
        }
    }
}
