using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterOponentName : ContentPage
    {
        public EnterOponentName()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_OponentName.TextColor = Constants.MainTextColor;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;
            Entry_OponentName.Text = Constants.OponentName;
        }

        public async void SubmitProcedure(object e, EventArgs s)
        {
            if (Validation.UsernamePatternMatch(Entry_OponentName.Text))
            {
                Constants.OponentName = Entry_OponentName.Text;
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert(Labels.Failed, Labels.OpNameNotMatch, Labels.Ok);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}