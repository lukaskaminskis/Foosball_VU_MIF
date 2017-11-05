using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

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

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_RepeatPassword.Focus();
            Entry_RepeatPassword.Completed += (s, e) => Entry_Email.Focus();
        }

        async void RegisterProcedure(object e, EventArgs s)
        {
            try
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
                else if (!Validation.EmailPatternMatch(Entry_Email.Text))
                {
                    await DisplayAlert(Labels.Failed, Labels.EmailNotMatch, Labels.Ok);
                }
                else
                {
                    User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text, Email: Entry_Email.Text);
                    bool fileExists = await FileManagement.PCLHelper.IsFileExistAsync(Labels.UsersList);
                    if (!fileExists)
                    {
                        string text = String.Format("{0};{1};{2}|", user.UserId, user.GetPassword(), user.Email);
                        await FileManagement.PCLHelper.WriteTextAllAsync(Labels.UsersList, text);

                        Constants.LocalUser = user;
                        await DisplayAlert(Labels.Registration, Labels.RegSucc, Labels.Ok);
                        await Navigation.PushModalAsync(new PropertiesPage());
                    }
                    else
                    {
                        var users = new List<User>();
                        string text = await FileManagement.PCLHelper.ReadAllTextAsync(Labels.UsersList);
                        FileProcedures file = new FileProcedures();
                        users = file.UserList(text);

                        var regUser = (from selectUser in users
                                      where selectUser.UserId == user.UserId
                                      select selectUser).Any();

                        if (regUser == false)
                        {
                            text = text + String.Format("{0};{1};{2}|", user.UserId, user.GetPassword(), user.Email);
                            await FileManagement.PCLHelper.DeleteFile(Labels.UsersList);
                            await FileManagement.PCLHelper.WriteTextAllAsync(Labels.UsersList, text);

                            Constants.LocalUser = user;
                            await DisplayAlert(Labels.Registration, Labels.RegSucc, Labels.Ok);
                            await Navigation.PushModalAsync(new PropertiesPage());
                        }
                        else
                        {
                            await DisplayAlert(Labels.Failed, Labels.UserExists, Labels.Ok);
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                await DisplayAlert("Exception", exc.ToString(), "Ok");
            }  
            
        }
    }
}