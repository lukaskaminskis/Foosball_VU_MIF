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
		

        public void SubmitProcedure(object e, EventArgs s)
        {
            if (Entry_GoalLimit.Text == null || Entry_GoalLimit.Text == "" 
                || Int32.Parse(Entry_GoalLimit.Text) > 10
                || Int32.Parse(Entry_GoalLimit.Text) <= 0)
            {
                DisplayAlert("Entry error", "Please enter valid goal limit", "Ok");
            }
            else
            {
                Constants.GoalLimit = Int32.Parse(Entry_GoalLimit.Text);
                Navigation.PushModalAsync(new PropertiesPage());
            }
        }
    }
}