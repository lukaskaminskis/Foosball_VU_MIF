using Foosball_Lib.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Foosball_Lib.Views
{
    public class EnterOponentNameViewModel : ContentPage
    {
        private ObservableCollection<string> _usersId;
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

        public EnterOponentNameViewModel()
        {
            UsersId = new ObservableCollection<string>
            {
                "First user",
                "Second User",
                "Third User",
            };
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
    }
}
