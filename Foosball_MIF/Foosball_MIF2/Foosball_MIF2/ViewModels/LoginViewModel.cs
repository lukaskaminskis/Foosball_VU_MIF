using Foosball_MIF2.Models;
using Foosball_MIF2.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Foosball_MIF2.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        //public string Lbl_Username => Labels.Username;
        public string Lbl_Username;
        public string Lbl_Password => Labels.Password;
        public string Btn_SignIn => Labels.SignIn;
        public string Lbl_Or => Labels.Or;
        public string Btn_Register => Labels.Register;

        private readonly INavigator _navigator;

        public LoginViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand SignInCommand
        {
            get
            {
                return new Command(() =>
                {
                    Lbl_Username = "Dick";
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }

    }
}
