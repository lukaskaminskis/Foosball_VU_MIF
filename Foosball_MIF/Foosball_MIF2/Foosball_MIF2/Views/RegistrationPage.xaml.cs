using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Foosball_Lib.FileManagement.BackEnd;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor                 = Constants.BackgroundColor;
            Lbl_Username.TextColor          = Constants.MainTextColor;
            Lbl_Password.TextColor          = Constants.MainTextColor;
            Lbl_RepeatPassword.TextColor    = Constants.MainTextColor;
            ActivitySpinner.IsVisible       = false;
            LogoIcon.HeightRequest          = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_RepeatPassword.Focus();
            Entry_RepeatPassword.Completed += (s, e) => Entry_Email.Focus();
        }

        async void RegisterProcedure(object e, EventArgs s)
        {
            BackEnd backEnd = new BackEnd();

            switch (await backEnd.BackEndAsync(Entry_Username.Text, Entry_Password.Text, Entry_RepeatPassword.Text, Entry_Email.Text))
            {
                case Message.RegexNoMatch:
                    await DisplayAlert(Labels.Failed, Labels.NoMatch, Labels.Ok);
                    break;
                case Message.PassNoMatch:
                    await DisplayAlert(Labels.Failed, Labels.PassNotMatch, Labels.Ok);
                    break;
                case Message.EmailNotMatch:
                    await DisplayAlert(Labels.Failed, Labels.EmailNotMatch, Labels.Ok);
                    break;
                case Message.RegSucc:
                    await DisplayAlert(Labels.Registration, Labels.RegSucc, Labels.Ok);
                    await Navigation.PushModalAsync(new PropertiesPage());
                    break;
                case Message.UserExists:
                    await DisplayAlert(Labels.Failed, Labels.UserExists, Labels.Ok);
                    break;
                case Message.Exc:
                    await DisplayAlert(Labels.Exc, Labels.Exception, Labels.Ok);
                    break;
            }
        }
    }   
}