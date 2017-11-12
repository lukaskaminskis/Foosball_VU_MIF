using Foosball_MIF2.FileManagement;
using Foosball_MIF2.Models;
using Foosball_MIF2.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Foosball_MIF2.Views
{
    public class ChooseOpponentViewModel : BaseViewModel
    {
        /*private ObservableCollection<string> _usersId;
        public ObservableCollection<string> UsersId
        {
            get
            {
                return _usersId;
            }
            set
            {
                _usersId = value;
                OnPropertyChanged();
            }
        }

        public ChooseOpponentViewModel()
        {
            Init();
        }

        private string _alertMessage;
        public string AlertMessage
        {
            get
            {
                return _alertMessage;
            }
            set
            {
                _alertMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand ItemClickedCommand
        {
            get
            {
                return new Command((item) => 
                {
                    AlertMessage = item as string;
                });
            }
        }

        async void Init()
        {
            UsersId = new ObservableCollection<string>();
            var users = new List<User>();
            BackEnd backEndOpponent = new BackEnd();
            users = await backEndOpponent.GetUsersList();
            foreach (User user in users)
            {
                if (user.UserId != Constants.LocalUser.UserId)
                {
                    UsersId.Add(user.UserId);
                }
            }
        } */
    }
}
