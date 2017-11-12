using Autofac;
using Foosball_MIF2.ViewModels;
using Foosball_MIF2.Views;

namespace Foosball_MIF2.Bootstrapping.Modules
{
    public class LoginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<LoginPage>().SingleInstance();
        }
    }
}
