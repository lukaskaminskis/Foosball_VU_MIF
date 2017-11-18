using Foosball_Lib.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;
using System.Collections.Generic;
using Foosball_Lib.FileManagement;
using System.Linq;

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

        async void Init()
        {
            Constants.userList          = await BackEnd.GetUserListAsync();
            //BackgroundColor             = Constants.BackgroundColor;
            Lbl_Username.TextColor      = Constants.MainTextColor;
            Lbl_Password.TextColor      = Constants.MainTextColor;
            ActivitySpinner.IsVisible   = false;
            LogoIcon.HeightRequest      = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus(); 
        }

        async void SignInProcedure(object e, EventArgs s)
        {
            try
            {
                User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text);
                bool fileExist = await FileManagement.PCLHelper.IsFileExistAsync(Labels.UsersList);
                if (fileExist)
                {
                    var LogUser = (from selectUser in Constants.userList
                                   where selectUser.UserId == user.UserId
                                   && selectUser.GetPassword() == user.GetPassword()
                                   select selectUser).Any();

                    if (LogUser == true)
                    {
                        Entry_Password.Text = "";
                        Entry_Username.Text = "";
                        Constants.LocalUser = user;
                        await DisplayAlert(Labels.Login, Labels.LoginSucc, Labels.Ok);
                        await Navigation.PushModalAsync(new PropertiesPage(), false);
                    }
                    else
                    {
                        await DisplayAlert(Labels.Failed, Labels.UserNotExists, Labels.Ok);
                    }
                }
                else
                {
                    await DisplayAlert(Labels.Failed, Labels.NoUsers, Labels.Ok);
                }
            }
            catch (Exception exc)
            {

            }
#if Debug
            catch (Exception exc)
            {
                await DisplayAlert("Exc", exc.ToString(), "ok");
            }
#endif 
        }

        void RegisterProcedure(object e, EventArgs s)
        {
            Navigation.PushModalAsync(new RegistrationPage(), false);
        }
    }
}