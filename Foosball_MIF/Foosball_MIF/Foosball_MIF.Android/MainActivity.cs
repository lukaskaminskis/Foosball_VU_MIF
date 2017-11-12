using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Collections.Generic;

namespace Foosball_MIF.Droid
{
    [Activity (Label = "Foosball_MIF", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            Dictionary<Type, Type> mappedTypes = new Dictionary<Type, Type>();

            var app = new App();
            app.LoadTypes(mappedTypes);
			LoadApplication (app);
		}
	}
}

