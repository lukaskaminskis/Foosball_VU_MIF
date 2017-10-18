using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;
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
            BackgroundColor             = Constants.BackgroundColor;
            Lbl_Username.TextColor      = Constants.MainTextColor;
            Lbl_Password.TextColor      = Constants.MainTextColor;
            ActivitySpinner.IsVisible   = false;
            LogoIcon.HeightRequest      = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object e, EventArgs s)
        {
            if (Validation.UsernamePatternMatch(Entry_Username.Text) && Validation.PasswordPatternMatch(Entry_Password.Text))
            {
                User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text);
                Entry_Username.Text = "";
                Entry_Password.Text = "";
                Constants.LocalUser = user;
                DisplayAlert(Labels.Login, Labels.LoginSucc, Labels.Ok);
                Navigation.PushModalAsync(new PropertiesPage());
            }
            else
            {
                DisplayAlert(Labels.Failed, Labels.NoMatch, Labels.Ok);
            }

        }

        void RegisterProcedure(object e, EventArgs s)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }

    }
}