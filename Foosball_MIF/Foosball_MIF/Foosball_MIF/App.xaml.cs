﻿using Foosball_Lib.Bootstrapping;
using Foosball_Lib.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Foosball_MIF
{
	public partial class App : Application
	{
		public App ()
		{

			InitializeComponent();
			//MainPage = new LoginPage();
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

        internal void LoadTypes(Dictionary<Type, Type> mappedTypes)
        {
            //var bootstrapper = new Bootstrapper();
            //bootstrapper.RunWithMappedTypes(mappedTypes);
        }
    }

}
