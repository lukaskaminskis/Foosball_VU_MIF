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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object e, EventArgs s)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            Constants.LocalUser = user;
            if (user.CheckInformation())
            {
                DisplayAlert("Login","Login succesful", "Ok");
                Navigation.PushModalAsync(new PropertiesPage());
            }
            else
            {
                DisplayAlert("Login", "Login failed, empty password or username", "Ok");
            }

        }

        void RegisterProcedure()
        {

        }
    }
}