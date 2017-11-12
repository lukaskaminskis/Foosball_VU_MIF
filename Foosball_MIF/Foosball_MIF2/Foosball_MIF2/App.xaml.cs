using Foosball_MIF2.Bootstrapping;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Foosball_MIF2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //LoadTypes();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void LoadTypes(Dictionary<Type, Type> mappedTypes)
        {
            var bootstrapper = new Bootstrapper(this);
            bootstrapper.RunWithMappedTypes(mappedTypes);
        }
    }
}
