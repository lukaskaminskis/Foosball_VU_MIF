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

        async void Init()
        {
            var userList = await BackEnd.GetUserListAsync();
            foreach (User user in userList)
            {
                if (user.UserId != Constants.LocalUser.UserId)
                {
                    opponentList.Add(user);
                }
            }
            MyListView.ItemsSource = opponentList;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            selectedUser = e.Item as User;

            await DisplayAlert("Item Tapped", "Username : " + selectedUser.UserId + " Password : " + selectedUser.GetPassword(), "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        async void StartMatch(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                await DisplayAlert("Ok", $"You selected {selectedUser.UserId} ", "Ok");
            }
            else
            {
                await DisplayAlert("Ok", "Player not selected", "Ok");
            }
        }

        async void DisplayPlayerInfo(object sender, EventArgs e)
        {

        }
    }
}
