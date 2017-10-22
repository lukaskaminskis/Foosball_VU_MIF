using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLStorage;
using Newtonsoft.Json;
using System.Text;

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

        async void SignInProcedure(object e, EventArgs s)
        {
            User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text);
            string txt = Entry_Username.Text + ".txt";
            bool fileexist = await FileManagement.PCLHelper.IsFileExistAsync(txt);
            if (fileexist)
            {
                Entry_Username.Text = "";
                Entry_Password.Text = "";
                txt = "";
                Constants.LocalUser = user;
                await DisplayAlert(Labels.Login, Labels.LoginSucc, Labels.Ok);
                await Navigation.PushModalAsync(new PropertiesPage());
            }
            else 
            {
                await DisplayAlert("Login", "You are not registered yet.  ", "OK");
            }
        }

        void RegisterProcedure(object e, EventArgs s)
        {
            Navigation.PushModalAsync(new RegistrationPage());

        }

        public string ContentBuilder(params string[] content)
        {
            StringBuilder contentbuilder = new StringBuilder();
            foreach (var item in content)
            {
                contentbuilder.AppendLine(item.ToString());
            }
            return contentbuilder.ToString();
        }

    }
}