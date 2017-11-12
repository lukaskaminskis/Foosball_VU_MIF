using Autofac;
using Foosball_MIF2;
using Foosball_MIF2.Views;
using Foosball_MIF2.ViewModels;

namespace Foosball_Lib.Bootstrapping
{
    public class Bootstrapper : AutofacBoostrapper
    {
        private App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var chooseOpponent = container.Resolve<ChooseOpponentPage>();
            var chooseOpponentViewModel = container.Resolve<ChooseOpponentViewModel>();
            chooseOpponente.BindingContext = chooseOpponentViewModel;
            _app.MainPage = chooseOpponent;
        }

        protected override void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<ChooseOpponentPage>().SingleInstance();
            builder.RegisterType<ChooseOpponentViewModel>().SingleInstance();
        }
    }
}
