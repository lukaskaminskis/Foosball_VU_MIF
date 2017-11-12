using Autofac;
using Foosball_MIF2.Bootstrapping.Modules;
using Foosball_MIF2.Factory;
using Foosball_MIF2.ViewModels;
using Foosball_MIF2.Views;
using Xamarin.Forms;

namespace Foosball_MIF2.Bootstrapping
{
    public class Bootstrapper : AutofacBoostrapper
    {
        private App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<MainModule>();
            builder.RegisterModule<LoginModule>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            //var chooseOpponent = container.Resolve<ChooseOpponentPage>();
            //var chooseOpponentViewModel = container.Resolve<ChooseOpponentViewModel>();
            //chooseOpponent.BindingContext = chooseOpponentViewModel;
            var viewFactory = container.Resolve<IViewFactory>();
            var loginPage = viewFactory.Resolve<LoginViewModel>();
            var navPage = new NavigationPage(loginPage);
            _app.MainPage = navPage;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            //builder.RegisterType<ChooseOpponentPage>().SingleInstance();
            //builder.RegisterType<ChooseOpponentViewModel>().SingleInstance();
            viewFactory.Register<LoginViewModel, LoginPage>();
            viewFactory.Register<ChooseOpponentViewModel, ChooseOpponentPage>();
        }
    }
}
