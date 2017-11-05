using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Foosball_Lib.FileManagement.RegistrationBackEnd;

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
            RegistrationBackEnd backEnd = new RegistrationBackEnd();

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
                    
            /*try
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
                else if (Validation.EmailPatternMatch(Entry_Email.Text))
                {
                    await DisplayAlert(Labels.Failed, Labels.EmailNotMatch, Labels.Ok);
                }
                else
                {
                    User user = new User(UserId: Entry_Username.Text, Password: Entry_Password.Text, Email: Entry_Email.Text);
                    bool fileExists = await FileManagement.PCLHelper.IsFileExistAsync(Labels.UsersList);
                    if (!fileExists)
                    {
                        //await FileManagement.PCLHelper.CreateFile(Labels.UsersList);
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
            */
            
        }
        /*public string ContentBuilder(params string[] content)
        {
            StringBuilder contentbuilder = new StringBuilder();
            foreach (var item in content)
            {
                contentbuilder.AppendLine(item.ToString());
            }
            return contentbuilder.ToString();
        } */
    }
            /*else
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

            }*/
    
}