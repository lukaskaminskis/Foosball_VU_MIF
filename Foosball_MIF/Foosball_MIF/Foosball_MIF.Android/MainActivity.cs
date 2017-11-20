﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Foosball_MIF.Droid
{
	[Activity (Label = "Foosball_MIF", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
		protected override  void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);


            CrossMedia.Current.Initialize();


			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new Foosball_MIF.App ());
		}

       
	}

}

