using Autofac;
using Foosball_MIF2.Factory;
using Foosball_MIF2.Services;
using Xamarin.Forms;

namespace Foosball_MIF2.Bootstrapping.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.Register<INavigation>(context => App.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
