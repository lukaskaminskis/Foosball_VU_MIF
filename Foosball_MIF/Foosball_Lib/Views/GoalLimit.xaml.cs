using Foosball_Lib.Models;
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
    public partial class GoalLimit : ContentPage
    {
        public GoalLimit()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_GoalLimit.TextColor = Constants.MainTextColor;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;
            Entry_GoalLimit.Text = Constants.GoalLimit.ToString();
        }

        public async void SubmitProcedure(object e, EventArgs s)
        {
            if (Checkgoallimit(Entry_GoalLimit.Text))
            {
                DisplayAlert("Entry error", "Please enter valid goal limit", "Ok");
            }
            else
            {
                Constants.GoalLimit = Int32.Parse(Entry_GoalLimit.Text);
                //Navigation.PushModalAsync(new PropertiesPage());
                await Navigation.PopModalAsync();
            }
        }
        public static bool Checkgoallimit(string Entry_Limit)
        {
            return (Entry_Limit == null || Entry_Limit == ""
                || Int32.Parse(Entry_Limit) > 10
                    || Int32.Parse(Entry_Limit) <= 0);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}