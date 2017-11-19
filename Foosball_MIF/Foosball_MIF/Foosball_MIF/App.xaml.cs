using Foosball_Lib.Views;
using Foosball_Lib.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Foosball_Lib.FileManagement;

namespace Foosball_MIF
{
	public partial class App : Application
	{
        public static void Init(IValidation ValidationImpl)
        {
            RegistrationBackEnd.RemoteValidation = ValidationImpl;
        }

        public App ()
		{

            //InitializeComponent();
			MainPage = new LoginPage();
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}

}
