using Foosball_Lib.Models;
using Foosball_Lib.Validations;
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
        }

        void RegisterProcedure(object e, EventArgs s)
        {
            if (!Validation.UsernamePatternMatch(Entry_Username.Text)
                && !Validation.PasswordPatternMatch(Entry_Password.Text)
                && !Validation.PasswordPatternMatch(Entry_RepeatPassword.Text))
            {
                DisplayAlert(Labels.Failed, Labels.NoMatch, Labels.Ok);
            }
            else if (Entry_Password.Text != Entry_RepeatPassword.Text)
            {
                DisplayAlert(Labels.Failed, Labels.PassNotMatch, Labels.Ok);
            }
            else if (Validation.EmailPatternMatch(Entry_Email.Text))
            {
                DisplayAlert(Labels.Failed, Labels.EmailNotMatch, Labels.Ok);
            }
            else
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text, Entry_Email.Text);

            }
        }
    }
}