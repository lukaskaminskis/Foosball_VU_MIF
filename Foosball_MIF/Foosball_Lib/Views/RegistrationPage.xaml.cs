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

        async void RegisterProcedure(object e, EventArgs s)
        {
            if (!Validation.UsernamePatternMatch(Entry_Username.Text)
                && !Validation.PasswordPatternMatch(Entry_Password.Text)
                && !Validation.PasswordPatternMatch(Entry_RepeatPassword.Text))
            {
               await DisplayAlert(Labels.Failed, Labels.NoMatch, Labels.Ok);
            }
            else if (Entry_Password.Text != Entry_RepeatPassword.Text)
            {
                await DisplayAlert(Labels.Failed, Labels.PassNotMatch, Labels.Ok);
            }
            //else if (Validation.EmailPatternMatch(Entry_Email.Text))
            //{
            //    await DisplayAlert(Labels.Failed, Labels.EmailNotMatch, Labels.Ok);
            //}
            else
            {
                User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text);
                bool result = false;
                string txt = Entry_Username.Text + ".txt";
                bool fileexist = await FileManagement.PCLHelper.IsFileExistAsync(txt);
                if (fileexist != true)
                {
                    if (Entry_Username.Text != "" && Entry_Password.Text != "" && Entry_RepeatPassword.Text != "" )
                        result = await FileManagement.PCLHelper.WriteTextAllAsync(txt,ContentBuilder(Entry_Username.Text, Entry_Password.Text));

                    if (!result)
                    {
                        await DisplayAlert("Registration", "Registrtion Fail .. Please try again ", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Registration", "Registrtion Success ... ", "OK");
                        Constants.LocalUser = user;
                        await Navigation.PushModalAsync(new PropertiesPage());
                    }
                }
                else
                {
                    await DisplayAlert("Registrtion Failed", "username already exist .. ", "OK");
                    Entry_Username.Text = "";
                    txt = "";
                    Entry_Username.Focus();

                }

            }
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