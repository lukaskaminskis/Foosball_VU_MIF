using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TodoWCFService;
using System.ServiceModel;

namespace Foosball_MIF.Droid
{
	[Activity (Label = "Foosball_MIF", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            ITodoService todoService = new TodoServiceClient(
                new BasicHttpBinding(),
                new EndpointAddress("http://192.168.43.42/foos/TodoService.svc"));

            System.Console.WriteLine("Response:");
            System.Console.WriteLine(todoService.UsernamePatternMatch("jonas"));
            TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new Foosball_MIF.App ());
		}
	}
}

